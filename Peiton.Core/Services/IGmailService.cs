namespace Peiton.Core.Services;

public interface IGmailService
{
    Task EnviarMensajeAsync(string email, string name, string subject, string body);
}
