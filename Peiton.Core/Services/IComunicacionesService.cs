namespace Peiton.Core.Services;

public interface IComunicacionesService
{
    void EnviarMensaje(int userId, IEnumerable<int>? recipientsUsers, IEnumerable<int>? recipientGroups, string subject, string body, string? className);
}