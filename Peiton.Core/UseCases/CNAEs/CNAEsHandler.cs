using Peiton.Contracts.CNAEs;
using Peiton.Contracts.Common;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.CNAEs;

[Injectable]
public class CNAEsHandler(ICNAERepository cnaeRepository)
{
    public async Task<PaginatedData<CNAEViewModel>> HandleAsync(ObtenerCNAEsFilter filter, Pagination pagination)
    {
        IEnumerable<CNAEViewModel> items = await cnaeRepository.ObtenerCNAEsAsync(pagination.Page, pagination.Total, filter);
        int total = await cnaeRepository.ContarCNAEsAsync(filter);

        return new PaginatedData<CNAEViewModel>()
        {
            Items = items,
            Total = total
        };
    }

}
