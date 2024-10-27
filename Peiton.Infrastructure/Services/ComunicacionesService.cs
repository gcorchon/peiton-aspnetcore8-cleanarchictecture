using Peiton.Core;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure;

[Injectable(typeof(IComunicacionesService))]
public class ComunicacionesService(IIdentityService identityService) : IComunicacionesService
{
    public void EnviarMensaje(IEnumerable<int> userIds, IEnumerable<int>? groupIds, string subject, string body, string? className)
    {
        this.EnviarMensaje(identityService.GetUserId(), userIds, groupIds, subject, body, className);
    }

    public void EnviarMensaje(int userId, IEnumerable<int> userIds, IEnumerable<int>? groupIds, string subject, string body, string? className)
    {
        this.EnviarMensaje(userId, userIds, groupIds, null, null, subject, body, className);
    }

    public void EnviarMensaje(IEnumerable<int> userIds, IEnumerable<int>? groupIds, IEnumerable<int>? userCcIds, IEnumerable<int>? groupCcIds, string subject, string body, string? cssClass)
    {
        this.EnviarMensaje(identityService.GetUserId(), userIds, groupIds, userCcIds, groupCcIds, subject, body, cssClass);
    }
    public void EnviarMensaje(int userId, IEnumerable<int> userIds, IEnumerable<int>? groupIds, IEnumerable<int>? userCcIds, IEnumerable<int>? groupCcIds, string subject, string body, string? cssClass)
    {
        //throw new NotImplementedException();
        Console.WriteLine("Enviando mensaje...");
    }
}
