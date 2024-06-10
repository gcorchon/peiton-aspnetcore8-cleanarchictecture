using Peiton.Contracts.Asientos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.Asientos;

[Injectable]
public class ActualizarAsientoHandler(IAsientoRepository asientoRepository, IFacturaRepository facturaRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(int id, AsientoSaveRequest item)
    {
        var asiento = await asientoRepository.GetByIdAsync(id);
        if (asiento is null)
        {
            throw new NotFoundException($"No existe el asiento con Id {id}");
        }

        int multiplicador = item.TipoMovimiento!.Value == 1 ? -1 : 1;

        asiento.Concepto = item.Concepto;
        asiento.PartidaId = item.PartidaId;
        asiento.FechaAutorizacion = item.FechaAutorizacion;
        asiento.Importe = multiplicador * Math.Abs(item.Importe);
        asiento.TipoPago = item.TipoPago;
        asiento.TipoMovimiento = item.TipoMovimiento;
        asiento.FormaPagoId = item.FormaPagoId;
        asiento.TuteladoId = item.TuteladoId;
        asiento.ClienteId = item.ClienteId;

        foreach (var factura in asiento.Facturas)
        {
            if (!item.FacturaIds.Contains(factura.Id))
            {
                factura.AsientoId = null;
            }
        }

        foreach (int facturaId in item.FacturaIds)
        {
            var factura = await facturaRepository.GetByIdAsync(facturaId);
            if (factura == null)
            {
                throw new ArgumentException($"La factura {facturaId} no existe", "facturaIds");
            }

            if (factura.AsientoId != asiento.Id)
            {
                factura.FechaPago = asiento.FechaPago;
                factura.NumeroMovimiento = asiento.Numero.ToString();
                asiento.Facturas.Add(factura);
            }
        }

        await unityOfWork.SaveChangesAsync();
    }
}