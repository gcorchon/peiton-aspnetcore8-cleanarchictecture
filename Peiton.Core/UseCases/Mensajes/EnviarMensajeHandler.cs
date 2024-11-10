using Peiton.Contracts.Mensajes;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Mensajes;

[Injectable]
public class EnviarMensajeHandler(IComunicacionesService comunicacionesService)
{
    public async Task HandleAsync(EnviarMensajeRequest request)
    {
        Whasapeiton whasapeiton = new()
        {
            Body = request.Cuerpo,
            Subject = request.Asunto,
            CssClass = null,
            UserIds = request.Para.Where(o => o.Tipo == 1).Select(o => o.Id),
            GroupIds = request.Para.Where(o => o.Tipo == 2).Select(o => o.Id),
            UserCcIds = request.ConCopia.Where(o => o.Tipo == 1).Select(o => o.Id),
            GroupCcIds = request.ConCopia.Where(o => o.Tipo == 2).Select(o => o.Id)
        };

        await comunicacionesService.EnviarMensajeAsync(whasapeiton);
    }
}