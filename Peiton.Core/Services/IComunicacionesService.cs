using Peiton.Contracts.Mensajes;

namespace Peiton.Core.Services;

public interface IComunicacionesService
{
    Task EnviarMensajeAsync(int userId, Whasapeiton whasapeiton);
    Task EnviarMensajeAsync(Whasapeiton whasapeiton);
}