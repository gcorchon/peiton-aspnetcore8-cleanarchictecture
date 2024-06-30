using Peiton.Contracts.AvisosTributarios;
using Peiton.Contracts.Common;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.InmuebleAvisos;

[Injectable]
public class AvisosHandler(IInmuebleAvisoRepository inmuebleAvisoRepository)
{
    public async Task<PaginatedData<InmuebleAviso>> HandleAsync(InmuebleAvisosFilter filter, Pagination pagination)
    {
        var items = await inmuebleAvisoRepository.ObtenerAvisosAsync(pagination.Page, pagination.Total, filter);
        var total = await inmuebleAvisoRepository.ContarAvisosAsync(filter);

        return new PaginatedData<InmuebleAviso>()
        {
            Items = items,
            Total = total
        };
    }

}
