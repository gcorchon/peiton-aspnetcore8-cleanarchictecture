using System.Xml.Linq;
using Newtonsoft.Json;
using Peiton.Contracts.MensajesTuAppoyo;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.MensajesTuAppoyo;

[Injectable]
public class EnviarMensajeTuAppoyoHandler(IMensajeTuteladoRepository mensajeTuteladoRepository, IUsuarioRepository usuarioRepository,
                    ITuteladoRepository tuteladoRepository, IIdentityService identityService, IUnitOfWork unitOfWork, IWebPushService webPushService)
{
    public async Task HandleAsync(CrearMensajeRequest request)
    {
        var usuario = await usuarioRepository.GetByIdAsync(identityService.GetUserId());
        var tutelado = await tuteladoRepository.GetByIdAsync(request.TuteladoId);

        if (usuario == null || tutelado == null) throw new ArgumentException();

        var mensajeTutelado = new MensajeTutelado()
        {
            Asunto = request.Asunto,
            Cuerpo = request.Cuerpo,
            Fecha = DateTime.Now,
            Info = new XDocument(
                        new XElement("datos",
                                new XElement("remitente",
                                    new XAttribute("id", usuario.Id),
                                    new XAttribute("nombre", usuario.NombreCompleto),
                                    new XAttribute("tipo", "usuario")),
                                new XElement("destinatarios",
                                    new XElement("tutelado",
                                        new XAttribute("id", tutelado.Id),
                                        new XAttribute("nombre", tutelado.NombreCompleto!))))).ToString()
        };

        mensajeTuteladoRepository.Add(mensajeTutelado);
        await unitOfWork.SaveChangesAsync();

        var payload = JsonConvert.SerializeObject(new { notification = new { title = "Tu Appoyo", body = "Tienes un mensaje nuevo de " + usuario.NombreCompleto } });
        await webPushService.SendNotificationAsync(tutelado.Id, "https://tuappoyo.com/mis-comunicaciones/" + mensajeTutelado.Id, payload);
    }
}