using AutoMapper;
using Peiton.Contracts.Common;
using Peiton.Contracts.Facturas;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Facturas;

[Injectable]
public class FacturasParaAsociarHandler(IMapper mapper, IFacturaRepository facturaRepository)
{
    public async Task<PaginatedData<FacturaListItem>> HandleAsync(FacturasFilter filter, Pagination pagination)
    {
        var asientos = await facturaRepository.ObtenerFacturasAsync(pagination.Page, pagination.Total, filter);
        var total = await facturaRepository.ContarFacturasAsync(filter);

        var vm = mapper.Map<IEnumerable<FacturaListItem>>(asientos);

        return new PaginatedData<FacturaListItem>()
        {
            Items = vm,
            Total = total
        };
    }
}