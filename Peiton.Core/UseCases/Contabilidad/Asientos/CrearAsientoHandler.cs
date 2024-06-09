using Peiton.Contracts.Asientos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.Asientos;

[Injectable]
public class CrearAsientoHandler(IAsientoRepository asientoRepository, IFacturaRepository facturaRepository, IUnityOfWork unityOfWork)
{    
    public async Task HandleAsync(AsientoSaveRequest item)
    {
        int multiplicador = item.TipoMovimiento!.Value == 1 ? -1 : 1;

        var asiento = new Asiento
        {
            Numero = await asientoRepository.ObtenerUltimoNumeroAsientoAsync(item.FechaAutorizacion!.Value.Year) + 1,
            Concepto = item.Concepto,
            PartidaId = item.PartidaId,
            FechaAutorizacion = item.FechaAutorizacion,
            FechaPago = null,
            Importe = multiplicador * Math.Abs(item.Importe!.Value),
            TipoPago = item.TipoPago,
            TipoMovimiento = item.TipoMovimiento,
            FormaPagoId = item.FormaPagoId,
            TuteladoId = item.TuteladoId,
            ClienteId = item.ClienteId
        };

        foreach (int facturaId in item.FacturaIds) {
            var factura = await facturaRepository.GetByIdAsync(facturaId);
            if (factura == null) {
                throw new ArgumentException($"La factura {facturaId} no existe");
            }
            asiento.Facturas.Add(factura);
        }

        await asientoRepository.AddAsync(asiento);
        await unityOfWork.SaveChangesAsync();
    }
}