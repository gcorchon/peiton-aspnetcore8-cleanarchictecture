using Peiton.Contracts.Common;
using Peiton.Contracts.Vales;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.Vales;

[Injectable]
public class ValesHandler(IValeRepository valeRepository)
{
    public async Task<PaginatedData<Vale>> HandleAsync(ValesFilter filter, Pagination pagination)
    {
        var items = await valeRepository.ObtenerValesAsync(pagination.Page, pagination.Total, filter);
        var total = await valeRepository.ContarValesAsync(filter);

        return new PaginatedData<Vale>()
        {
            Items = items,
            Total = total
        };
    }

}
