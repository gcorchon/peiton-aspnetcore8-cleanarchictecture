using System.Xml.Linq;
using Peiton.Contracts.Mensajes;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tareas;

[Injectable]
public class TareasHelper(ITareaRepository tareaRepository,
                        IUsuarioRepository usuarioRepository, IGrupoRepository grupoRepository,
                        IComunicacionesService comunicacionesService)
{

    internal async Task EnviarNuevaTareaADistribuidorAsync(int tareaId)
    {

        var tarea = await tareaRepository.GetByIdAsync(tareaId) ?? throw new NotFoundException("Tarea no encontrada");
        if (!tarea.UsuarioDistribuidorId.HasValue) return;

        var tutelado = tarea.Tutelado;
        var solicitante = tarea.UsuarioSolicitante;

        await comunicacionesService.EnviarMensajeAsync(new Whasapeiton()
        {
            UserIds = [tarea.UsuarioDistribuidorId.Value],
            Subject = string.Format("Nueva tarea asignada para distribución del tutelado {0} Nº Exp {1}", tutelado.NombreCompleto, tutelado.NumeroExpediente),
            Body = string.Format("{0} te ha asignado una nueva tarea relacionada con el tutelado {1} Nº Exp {2} para su distribución\r\n\r\nMotivo de la solicitud: {3}",
                            solicitante.NombreCompleto, tutelado.NombreCompleto, tutelado.NumeroExpediente, tarea.Motivo)
        });
    }

    internal async Task EnviarNuevaTareaAGestorAsync(int tareaId)
    {
        var tarea = await tareaRepository.GetByIdAsync(tareaId) ?? throw new NotFoundException("Tarea no encontrada");
        if (!tarea.UsuarioGestorId.HasValue) return;

        var tutelado = tarea.Tutelado;
        var solicitante = tarea.UsuarioSolicitante;

        await comunicacionesService.EnviarMensajeAsync(new Whasapeiton()
        {
            UserIds = [tarea.UsuarioGestorId.Value],
            Subject = string.Format("Nueva tarea asignada para gestión del tutelado {0} Nº Exp {1}", tutelado.NombreCompleto, tutelado.NumeroExpediente),
            Body = string.Format("{0} te ha asignado una nueva tarea relacionada con el tutelado {1} Nº Exp {2} para su gestión\r\n\r\nMotivo de la solicitud: {3}",
                        solicitante.NombreCompleto, tutelado.NombreCompleto, tutelado.NumeroExpediente, tarea.Motivo)
        });
    }

    internal async Task ComunicarFinalizacionTareaAsync(int tareaId)
    {
        var tarea = await tareaRepository.GetByIdAsync(tareaId) ?? throw new NotFoundException("Tarea no encontrada");

        var tutelado = tarea.Tutelado;

        var texto = new List<string>()
            {
                string.Format("La tarea del tutelado {0} Nº Exp {1} ha pasado a estado finalizado", tutelado.NombreCompleto, tutelado.NumeroExpediente),
                "",
                string.Format("Motivo de la solicitud: {0}", tarea.Motivo),
            };

        await comunicacionesService.EnviarMensajeAsync(new Whasapeiton()
        {
            UserIds = [tarea.UsuarioSolicitanteId],
            Subject = string.Format("La tarea del tutelado {0} Nº Exp {1} ha pasado a estado finalizado", tutelado.NombreCompleto, tutelado.NumeroExpediente),
            Body = string.Join("\r\n", texto)
        });
    }

    internal async Task ComunicarCambiosEnComentariosAsync(int tareaId, bool haCambiadoComentarioGestor, bool haCambiadoComentarioDistribuidor)
    {
        var tarea = await tareaRepository.GetByIdAsync(tareaId) ?? throw new NotFoundException("Tarea no encontrada");

        var tutelado = tarea.Tutelado;

        var campos = new List<string>();
        if (haCambiadoComentarioGestor) { campos.Add("los comentarios del gestor"); }
        if (haCambiadoComentarioDistribuidor) { campos.Add("los comentarios del distribuidor"); }

        var texto = new List<string>() {
             string.Format("Se han modificado {2} de la tarea del tutelado {0} Nº Exp {1}.", tutelado.NombreCompleto, tutelado.NumeroExpediente, string.Join(" y ", campos)),
             "",
             string.Format("Motivo de la solicitud: {0}", tarea.Motivo),
             ""
            };

        if (haCambiadoComentarioGestor)
        {
            texto.Add("Comentarios del gestor: " + tarea.ComentariosGestor);
            texto.Add("");
        }

        if (haCambiadoComentarioDistribuidor)
        {
            texto.Add("Comentarios del distribuidor: " + tarea.ComentariosDistribuidor);
            texto.Add("");
        }

        await comunicacionesService.EnviarMensajeAsync(new Whasapeiton()
        {
            UserIds = [tarea.UsuarioSolicitanteId],
            Subject = string.Format("Comentarios añadidos a la tarea del tutelado {0} Nº Exp {1}", tutelado.NombreCompleto, tutelado.NumeroExpediente),
            Body = string.Join("\r\n", texto)
        });
    }

    public async Task CargarAlertasAsync(Tarea tarea, IEnumerable<DestinatarioMensajeRequest> alertas)
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
                var xdoc = string.IsNullOrWhiteSpace(tarea.AlertasEnviadas) ?
                                XDocument.Parse("<alertas></alertas>") : XDocument.Parse(tarea.AlertasEnviadas);

                xdoc.Root!.Add(new XElement("alerta",
                                    new XAttribute("fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    string.Join(", ", destinatarios)));

                tarea.AlertasEnviadas = xdoc.ToString();
            }
        }
    }


    public async Task EnviarAlertasAsync(int tareaId, IEnumerable<DestinatarioMensajeRequest> alertas)
    {
        if (alertas.Any())
        {
            var tarea = await tareaRepository.GetByIdAsync(tareaId) ?? throw new NotFoundException("Tarea no encontrada");
            var tutelado = tarea.Tutelado;

            var body = "<p>" + tarea.Motivo + "</p>";

            if (!string.IsNullOrWhiteSpace(tarea.ComentariosDistribuidor))
            {
                body += "<p><strong>Comentarios del distribuidor</strong><br />" + tarea.ComentariosDistribuidor.Replace("\n", "<br />") + "</p>";
            }

            if (!string.IsNullOrWhiteSpace(tarea.ComentariosGestor))
            {
                body += "<p><strong>Comentarios del gestor</strong><br />" + tarea.ComentariosGestor.Replace("\n", "<br />") + "</p>";
            }

            await comunicacionesService.EnviarMensajeAsync(
                new Whasapeiton()
                {
                    UserIds = alertas.Where(a => a.Tipo == 1).Select(a => a.Id),
                    GroupIds = alertas.Where(a => a.Tipo == 2).Select(a => a.Id),
                    Subject = "Tarea actualizada de " + tutelado.NombreCompleto,
                    Body = body
                }
            );
        }
    }
}