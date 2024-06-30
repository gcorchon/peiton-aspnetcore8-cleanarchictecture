using Peiton.Contracts.Common;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.InmuebleAutorizaciones;

[Injectable]
public class AutorizacionesHandler(IInmuebleAutorizacionRepository inmuebleAutorizacionRepository)
{
    public async Task<PaginatedData<InmuebleAutorizacion>> HandleAsync(InmuebleAutorizacionesFilter filter, Pagination pagination)
    {
        var items = await inmuebleAutorizacionRepository.ObtenerAutorizacionesAsync(pagination.Page, pagination.Total, filter);
        var total = await inmuebleAutorizacionRepository.ContarAutorizacionesAsync(filter);

        return new PaginatedData<InmuebleAutorizacion>()
        {
            Items = items,
            Total = total
        };
    }

}
