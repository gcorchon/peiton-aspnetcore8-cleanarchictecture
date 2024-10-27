namespace Peiton.Core.Services;

public interface IComunicacionesService
{
    void EnviarMensaje(int userId, IEnumerable<int> userIds, IEnumerable<int>? groupIds, string subject, string body, string? className);
    void EnviarMensaje(IEnumerable<int> userIds, IEnumerable<int>? groupIds, string subject, string body, string? className);
    void EnviarMensaje(int userId, IEnumerable<int> userIds, IEnumerable<int>? groupIds, IEnumerable<int>? userCcIds, IEnumerable<int>? groupCcIds, string subject, string body, string? className);
    void EnviarMensaje(IEnumerable<int> userIds, IEnumerable<int>? groupIds, IEnumerable<int>? userCcIds, IEnumerable<int>? groupCcIds, string subject, string body, string? className);
}