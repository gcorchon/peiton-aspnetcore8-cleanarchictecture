using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.MensajesTuAppoyo;

[Injectable]
public class BorrarMensajesTuAppoyoHandler(IMensajeTuteladoRepository mensajeTuteladoRepository)
{
    public async Task HandleAsync(int[] ids, string tipo)
    {
        switch (tipo.ToLower())
        {
            case "recibido":
                await mensajeTuteladoRepository.MarcarRecibidosComoBorradoAsync(ids);
                break;
            default:
                throw new NotImplementedException();
        }
    }
}