using Peiton.Contracts.Common;
using Peiton.Contracts.Salas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Salas;

[Injectable]
public class SalasPaginadasHandler(ISalaRepository salaRepository)
{
    public async Task<PaginatedData<Sala>> HandleAsync(SalasFilter filter, Pagination pagination)
    {
        var items = await salaRepository.ObtenerSalasAsync(pagination.Page, pagination.Total, filter);
        var total = await salaRepository.ContarSalasAsync(filter);

        return new PaginatedData<Sala>()
        {
            Items = items,
            Total = total
        };
    }
}