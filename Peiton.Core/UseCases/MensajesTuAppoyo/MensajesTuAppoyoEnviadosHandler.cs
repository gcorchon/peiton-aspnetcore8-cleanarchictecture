using Peiton.Contracts.Common;
using Peiton.Contracts.MensajesTuAppoyo;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.MensajesTuAppoyo;

[Injectable]
public class MensajesTuAppoyoEnviadosHandler(IMensajeTuteladoRepository mensajeRepository)
{
    public async Task<PaginatedData<MensajeTuAppoyoEnviadoListItem>> HandleAsync(MensajesTuAppoyoEnviadosFilter filter, Pagination pagination)
    {
        var items = await mensajeRepository.ObtenerMensajesEnviadosAsync(pagination.Page, pagination.Total, filter);
        var total = await mensajeRepository.ContarMensajesEnviadosAsync(filter);

        return new PaginatedData<MensajeTuAppoyoEnviadoListItem>()
        {
            Items = items,
            Total = total
        };
    }
}