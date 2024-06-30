using Peiton.Contracts.Common;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Sucesiones;

[Injectable]
public class SucesionesHandler(ISucesionRepository sucesionRepository)
{
    public async Task<PaginatedData<Sucesion>> HandleAsync(SucesionesFilter filter, Pagination pagination)
    {
        var items = await sucesionRepository.ObtenerSucesionesAsync(pagination.Page, pagination.Total, filter);
        var total = await sucesionRepository.ContarSucesionesAsync(filter);

        return new PaginatedData<Sucesion>()
        {
            Items = items,
            Total = total
        };
    }

}
