using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure;

[Injectable(typeof(IComunicacionesService))]
public class ComunicacionesService : IComunicacionesService
{
    public void EnviarMensaje(int userId, IEnumerable<int>? recipientsUsers, IEnumerable<int>? recipientGroups, string subject, string body, string? className)
    {

    }
}
