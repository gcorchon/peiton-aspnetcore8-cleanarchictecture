using Peiton.Contracts.Common;
using Peiton.Contracts.Sucursales;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Sucursales;

[Injectable]
public class SucursalesHandler(ISucursalRepository sucursalRepository)
{
    public async Task<PaginatedData<Sucursal>> HandleAsync(SucursalesFilter filter, Pagination pagination)
    {
        var items = await sucursalRepository.ObtenerSucursalesAsync(pagination.Page, pagination.Total, filter);
        var total = await sucursalRepository.ContarSucursalesAsync(filter);

        return new PaginatedData<Sucursal>()
        {
            Items = items,
            Total = total
        };
    }

}
