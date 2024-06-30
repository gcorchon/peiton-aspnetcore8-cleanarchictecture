using Peiton.Contracts.Common;
using Peiton.Contracts.Facturas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Facturas;

[Injectable]
public class FacturasHandler(IFacturaRepository facturaRepository)
{
    public async Task<PaginatedData<Factura>> HandleAsync(FacturasFilter filter, Pagination pagination)
    {
        var items = await facturaRepository.ObtenerFacturasAsync(pagination.Page, pagination.Total, filter);
        var total = await facturaRepository.ContarFacturasAsync(filter);

        return new PaginatedData<Factura>()
        {
            Items = items,
            Total = total
        };
    }

}