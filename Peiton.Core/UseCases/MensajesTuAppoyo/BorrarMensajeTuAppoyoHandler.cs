using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.MensajesTuAppoyo;

[Injectable]
public class BorrarMensajeTuAppoyoHandler(IMensajeTuteladoRepository mensajeTuteladoRepository)
{
    public async Task HandleAsync(int id, string tipo)
    {
        switch (tipo.ToLower())
        {
            case "recibido":
                await mensajeTuteladoRepository.MarcarRecibidoComoBorradoAsync(id);
                break;
            case "enviado":
                await mensajeTuteladoRepository.MarcarEnviadoComoBorradoAsync(id);
                break;
            default:
                throw new ArgumentException("Tipo de mensaje no válido");
        }
    }
}