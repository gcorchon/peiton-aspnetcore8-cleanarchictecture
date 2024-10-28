using Peiton.Contracts.Centros;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Centros;

[Injectable]
public class CentrosHandler(ICentroRepository centroRepository)
{
    public async Task<PaginatedData<Centro>> HandleAsync(CentrosFilter filter, Pagination pagination)
    {
        IEnumerable<Centro> items = await centroRepository.ObtenerCentrosAsync(pagination.Page, pagination.Total, filter);
        int total = await centroRepository.ContarCentrosAsync(filter);

        return new PaginatedData<Centro>()
        {
            Items = items,
            Total = total
        };
    }

}
