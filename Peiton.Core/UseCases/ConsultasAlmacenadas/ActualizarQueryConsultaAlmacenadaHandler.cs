using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ConsultasAlmacenadas;

[Injectable]
public class ActualizarQueryConsultaAlmacenadaHandler(IUnityOfWork unityOfWork, IEntityService entityService)
{
    public async Task HandleAsync(int id, string query)
    {
        var consultaAlmacenada = await entityService.GetEntityAsync<ConsultaAlmacenada>(id);
        if (consultaAlmacenada == null) throw new EntityNotFoundException();

        consultaAlmacenada.Query = query;

        await unityOfWork.SaveChangesAsync();
    }

}