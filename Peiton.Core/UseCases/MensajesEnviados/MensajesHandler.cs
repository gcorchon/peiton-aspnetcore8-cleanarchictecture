using Peiton.Contracts.Common;
using Peiton.Contracts.Mensajes;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.MensajesEnviados;

[Injectable]
public class MensajesHandler(IMensajeEnviadoRepository mensajeEnviadoRepository)
{
    public async Task<PaginatedData<MensajeEnviado>> HandleAsync(MensajesFilter filter, Pagination pagination)
    {
        var items = await mensajeEnviadoRepository.ObtenerMensajesAsync(pagination.Page, pagination.Total, filter);
        var total = await mensajeEnviadoRepository.ContarMensajesAsync(filter);

        return new PaginatedData<MensajeEnviado>()
        {
            Items = items,
            Total = total
        };
    }
}