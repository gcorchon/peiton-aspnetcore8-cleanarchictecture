using Peiton.Contracts.Common;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.InmuebleTasaciones;

[Injectable]
public class InmuebleTasacionesHandler(IInmuebleTasacionRepository inmuebletasacionRepository)
{
    public async Task<PaginatedData<InmuebleTasacion>> HandleAsync(InmuebleTasacionesFilter filter, Pagination pagination)
    {
        var items = await inmuebletasacionRepository.ObtenerInmuebleTasacionesAsync(pagination.Page, pagination.Total, filter);
        var total = await inmuebletasacionRepository.ContarInmuebleTasacionesAsync(filter);

        return new PaginatedData<InmuebleTasacion>()
        {
            Items = items,
            Total = total
        };
    }

}
