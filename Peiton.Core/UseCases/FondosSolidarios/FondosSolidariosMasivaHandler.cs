using Peiton.Contracts.Common;
using Peiton.Contracts.FondosSolidarios;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.FondosSolidarios;

[Injectable]
public class FondosSolidariosMasivaHandler(IFondoSolidarioRepository fondoSolidarioRepository)
{
    public async Task<PaginatedData<FondoSolidario>> HandleAsync(FondosSolidariosFilter filter, Pagination pagination)
    {
        var items = await fondoSolidarioRepository.ObtenerFondosSolidariosAsync(pagination.Page, pagination.Total, filter);
        var total = await fondoSolidarioRepository.ContarFondosSolidariosAsync(filter);

        return new PaginatedData<FondoSolidario>()
        {
            Items = items,
            Total = total
        };
    }
}