using Peiton.Contracts.Comunicaciones;

namespace Peiton.Core.Services;

public interface IComunicacionesService
{
    Task EnviarMensajeAsync(int userId, Whasapeiton whasapeiton);
    Task EnviarMensajeAsync(Whasapeiton whasapeiton);
}