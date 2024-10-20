using Peiton.Contracts.Quejas;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Quejas;

[Injectable]
public class QuejasHandler(IQuejaRepository quejaRepository)
{
    public async Task<PaginatedData<Queja>> HandleAsync(QuejasFilter filter, Pagination pagination)
    {
        var items = await quejaRepository.ObtenerQuejasAsync(pagination.Page, pagination.Total, filter);
        var total = await quejaRepository.ContarQuejasAsync(filter);

        return new PaginatedData<Queja>()
        {
            Items = items,
            Total = total
        };
    }

}
