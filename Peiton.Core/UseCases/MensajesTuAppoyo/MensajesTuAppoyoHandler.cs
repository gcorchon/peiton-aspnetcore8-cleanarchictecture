using Peiton.Contracts.Common;
using Peiton.Contracts.MensajesTuAppoyo;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.MensajesTuAppoyo;

[Injectable]
public class MensajesTuAppoyoHandler(IMensajeTuteladoRepository mensajeRepository)
{
    public async Task<PaginatedData<MensajeTuAppoyoListItem>> HandleAsync(MensajesTuAppoyoFilter filter, Pagination pagination)
    {
        var items = await mensajeRepository.ObtenerMensajesRecibidosAsync(pagination.Page, pagination.Total, filter);
        var total = await mensajeRepository.ContarMensajesRecibidosAsync(filter);

        return new PaginatedData<MensajeTuAppoyoListItem>()
        {
            Items = items,
            Total = total
        };
    }
}