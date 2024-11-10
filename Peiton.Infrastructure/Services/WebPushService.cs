
using Newtonsoft.Json;
using Peiton.Core;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using WebPush;

namespace Peiton.Infrastructure.Services;

[Injectable(typeof(IWebPushService))]
public class WebPushService(ITuteladoRepository tuteladoRepository) : IWebPushService
{
    private readonly string VAPID_PUBLIC_KEY = "BJGoHtB54Q7m4fuJsxnRtxpaz2cTOGVLkXBKsxH3Kwm2sr6chP9AA0cj7fCdhCavOaUsMkQPq6XISFBno7-IpRM";
    private readonly string VAPID_PRIVATE_KEY = "0AF4t8_8ZD_n1VhbhEDGv3PAqxYGqY9tbIF4e9mIoD8";
    public async Task SendNotificationAsync(int tuteladoId, string subject, string body)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId);
        if (tutelado == null) throw new EntityNotFoundException("Tutelado no encontrado");
        var teAppoyo = tutelado.TeAppoyo;

        if (teAppoyo == null || !teAppoyo.Enabled || string.IsNullOrWhiteSpace(teAppoyo.WebPushInfo)) return;

        var vapidDetails = new VapidDetails(subject, this.VAPID_PUBLIC_KEY, this.VAPID_PRIVATE_KEY);
        var wpInfo = JsonConvert.DeserializeObject<WebPushSubscriptionRequest>(teAppoyo.WebPushInfo);
        var subscription = new PushSubscription(wpInfo.Endpoint, wpInfo.Keys.P256Dh, wpInfo.Keys.Auth);
        var webPushClient = new WebPushClient();
        try
        {
            webPushClient.SendNotification(subscription, body, vapidDetails);
        }
        catch (WebPushException)
        {

        }
    }
}


internal class WebPushSubscriptionRequest
{
    public string Endpoint { get; set; } = string.Empty;
    public decimal? ExpirationTime { get; set; } = null;
    public WebPushKeys Keys { get; set; } = null!;
}

internal class WebPushKeys
{
    public string Auth { get; set; } = string.Empty;
    public string P256Dh { get; set; } = string.Empty;
}