using Peiton.Contracts.Common;
using Peiton.Contracts.Mensajes;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Mensajes;

[Injectable]
public class MensajesHandler(IMensajeRepository mensajeRepository)
{
    public async Task<PaginatedData<Mensaje>> HandleAsync(MensajesFilter filter, Pagination pagination)
    {
        var items = await mensajeRepository.ObtenerMensajesAsync(pagination.Page, pagination.Total, filter);
        var total = await mensajeRepository.ContarMensajesAsync(filter);

        return new PaginatedData<Mensaje>()
        {
            Items = items,
            Total = total
        };
    }
}