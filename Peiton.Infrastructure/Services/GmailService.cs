
using Peiton.Core.Services;
using Peiton.DependencyInjection;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Peiton.Infrastructure.Services;

[Injectable(typeof(IGmailService))]
public class GmailService : IGmailService
{
    private SmtpClient _smtp = null!;

    private SmtpClient Smtp
    {
        get
        {
            if (_smtp == null)
            {
                _smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("peiton@financialcodex.com", "C0c0lis0")
                };
            }

            return _smtp;
        }
    }

    public async Task EnviarMensajeAsync(string email, string name, string subject, string body)
    {
        MailMessage msg = new(new MailAddress("no-reply@financialcodex.com", "Peiton"), new MailAddress(email, body))
        {
            IsBodyHtml = true,
            Subject = subject,
            SubjectEncoding = Encoding.UTF8,
            BodyEncoding = Encoding.UTF8,
            Body = body
        };

        try
        {
            await this.Smtp.SendMailAsync(msg);
        }
        catch { }
    }
}
