using System.Xml.Linq;
using Microsoft.Extensions.Options;
using Peiton.Configuration;
using Peiton.Contracts.Mensajes;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Seguimientos;

[Injectable]
public class AlertasHelper(ITuteladoRepository tuteladoRepository,
                                     IUsuarioRepository usuarioRepository, IGrupoRepository grupoRepository,
                                     IComunicacionesService comunicacionesService,
                                     IOptions<AppSettings> appSettings)
{

    public async Task CargarAlertasAsync(Agenda seguimiento, IEnumerable<DestinatarioMensajeRequest> alertas)
    {
        if (alertas.Any())
        {
            var destinatarios = new List<string>();

            foreach (var destinatario in alertas.Where(a => a.Tipo == 1))
            {
                var usuario = await usuarioRepository.GetByIdAsync(destinatario.Id);
                if (usuario == null) continue;
                destinatarios.Add(usuario.NombreCompleto);
            }

            foreach (var destinatario in alertas.Where(a => a.Tipo == 2))
            {
                var grupo = await grupoRepository.GetByIdAsync(destinatario.Id);
                if (grupo == null) continue;
                destinatarios.Add(grupo.Descripcion);
            }

            if (destinatarios.Any())
            {
                var xdoc = string.IsNullOrWhiteSpace(seguimiento.AlertasEnviadas) ?
                                XDocument.Parse("<alertas></alertas>") : XDocument.Parse(seguimiento.AlertasEnviadas);

                xdoc.Root!.Add(new XElement("alerta",
                                    new XAttribute("fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    string.Join(", ", destinatarios)));

                seguimiento.AlertasEnviadas = xdoc.ToString();
            }
        }
    }

    public async Task EnviarAlertasAsync(Agenda seguimiento, IEnumerable<DestinatarioMensajeRequest> alertas)
    {
        if (alertas.Any())
        {
            var tutelado = await tuteladoRepository.GetByIdAsync(seguimiento.TuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");
            await comunicacionesService.EnviarMensajeAsync(
                new Whasapeiton()
                {
                    UserIds = alertas.Where(a => a.Tipo == 1).Select(a => a.Id),
                    GroupIds = alertas.Where(a => a.Tipo == 2).Select(a => a.Id),
                    Subject = "Seguimiento de " + tutelado.NombreCompleto,
                    Body = "<p>" + seguimiento.Descripcion + "</p><p>Puede consultar toda la información de seguimiento en " + appSettings.Value.BaseUrl + "/GestionIndividual/#!/" + tutelado.Id + "/Agenda</p>"
                }
            );
        }
    }
}