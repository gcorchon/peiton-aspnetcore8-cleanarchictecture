using Newtonsoft.Json;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Autorizaciones;

[Injectable]
public class SendPushHandler(IWebPushService webPushService)
{
    public async Task HandleAsync(int tuteladoId)
    {
        var payload = JsonConvert.SerializeObject(new { notification = new { title = "Tu Appoyo", body = "Tienes una solicitud nueva de autorización" } });
        await webPushService.SendNotificationAsync(tuteladoId, "https://tuappoyo.com/autorizaciones/", payload);
    }
}