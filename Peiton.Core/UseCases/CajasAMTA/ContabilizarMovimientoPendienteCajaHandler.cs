using Peiton.Contracts.Asientos;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.CajasAMTA;

[Injectable]
public class ContabilizarMovimientoPendienteCajaHandler(IEntityService entityService, IAsientoRepository asientoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, AsientoSaveRequest[] request)
    {
        var cajaAMTA = await entityService.GetEntityAsync<CajaAMTA>(id);
        if (cajaAMTA == null) throw new NotFoundException($"No existe la entrada de CajaAMTA con el Id {id}");

        var asientoList = cajaAMTA.Asientos;
        IEnumerable<int> asientosYaSeleccionados = request.Where(a => a.Id.HasValue).Select(a => a.Id!.Value);

        //Desasignar aquellos asientos que antes estuvieran seleccionados y que al salvar ya no vienen
        foreach (var asiento in asientoList.Where(a => !asientosYaSeleccionados.Contains(a.Id)))
        {
            asiento.CajaAMTAId = null;
            asiento.FechaPago = null;
        }

        var dictNumeroAsiento = new Dictionary<int, int>();

        foreach (var item in request)
        {
            int multiplicador = item.TipoMovimiento!.Value == 1 ? -1 : 1;

            Asiento asiento = null!;
            if (!item.Id.HasValue)
            {
                asiento = new Asiento();

                int year = item.FechaAutorizacion!.Value.Year;
                if (!dictNumeroAsiento.ContainsKey(year))
                    dictNumeroAsiento[year] = await asientoRepository.ObtenerUltimoNumeroAsientoAsync(item.FechaAutorizacion!.Value.Year) + 1;
                else
                    dictNumeroAsiento[year] = dictNumeroAsiento[year] + 1;

                asiento.Numero = dictNumeroAsiento[year];
                cajaAMTA.Asientos.Add(asiento);

                foreach (int facturaId in item.FacturaIds)
                {
                    var factura = await entityService.GetEntityAsync<Factura>(facturaId);
                    if (factura == null)
                    {
                        throw new ArgumentException($"La factura {facturaId} no existe");
                    }
                    factura.NumeroMovimiento = asiento.Numero.ToString();
                    factura.FechaPago = cajaAMTA.Fecha;
                    asiento.Facturas.Add(factura);
                }
            }
            else
            {
                int itemId = item.Id!.Value;
                var temp = await entityService.GetEntityAsync<Asiento>(itemId);
                if (temp != null)
                {
                    asiento = temp;
                    foreach (var factura in asiento.Facturas)
                    {
                        if (!item.FacturaIds.Contains(factura.Id))
                        {
                            factura.AsientoId = null;
                            factura.NumeroMovimiento = null;
                            factura.FechaPago = null;
                        }
                    }

                    foreach (int facturaId in item.FacturaIds)
                    {
                        var factura = await entityService.GetEntityAsync<Factura>(facturaId);
                        if (factura == null)
                        {
                            throw new ArgumentException($"La factura {facturaId} no existe");
                        }

                        if (factura.AsientoId != asiento.Id)
                        {
                            factura.FechaPago = cajaAMTA.Fecha;
                            factura.NumeroMovimiento = asiento.Numero.ToString();
                            asiento.Facturas.Add(factura);
                        }
                    }

                }
                else
                    throw new ArgumentException($"El asiento {itemId} no existe");
            }

            asiento.Concepto = item.Concepto;
            asiento.PartidaId = item.PartidaId;
            asiento.FechaAutorizacion = item.FechaAutorizacion;
            asiento.FechaPago = cajaAMTA.Fecha;
            asiento.Importe = multiplicador * Math.Abs(item.Importe);
            asiento.TipoPago = item.TipoPago;
            asiento.TipoMovimiento = item.TipoMovimiento;
            asiento.FormaPagoId = item.FormaPagoId;
            asiento.TuteladoId = item.TuteladoId;
            asiento.ClienteId = item.ClienteId;
        }

        await unitOfWork.SaveChangesAsync();

    }
}