namespace Peiton.Core;

public interface IWebPushService
{
    Task SendNotificationAsync(int tuteladoId, string subject, string body);
}