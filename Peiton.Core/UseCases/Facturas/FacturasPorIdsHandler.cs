using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Facturas;

[Injectable]
public class FacturasPorIdsHandler(IFacturaRepository facturaRepository)
{
    public Task<List<Factura>> HandleAsync(int[] ids) =>
        facturaRepository.ObtenerFacturasAsync(ids);
}