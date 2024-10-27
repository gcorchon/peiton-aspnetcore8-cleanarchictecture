using Newtonsoft.Json;
using Peiton.Authorization;
using Peiton.Contracts.Comunicaciones;
using Peiton.Core;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure;

[Injectable(typeof(IComunicacionesService))]
public class ComunicacionesService(IIdentityService identityService, IUnitOfWork unitOfWork, IGmailService gmailService, IUsuarioRepository usuarioRepository,
                                    IGrupoRepository grupoRepository, IMensajeRepository mensajeRepository,
                                    IMensajeEnviadoRepository mensajeEnviadoRepository, IAusenciaRepository ausenciaRepository) : IComunicacionesService
{
    public Task EnviarMensajeAsync(Whasapeiton whasapeiton)
    {
        return this.EnviarMensajeAsync(identityService.GetUserId(), whasapeiton);
    }

    public async Task EnviarMensajeAsync(int userId, Whasapeiton whasapeiton)
    {
        var sender = await usuarioRepository.GetByIdAsync(userId);

        if (sender == null) throw new ArgumentException("Invalid userId");

        var destinatarios = new List<DestinatarioMensaje>();
        var destinatariosCc = new List<DestinatarioMensaje>();

        var usuariosPara = whasapeiton.UserIds != null ? await usuarioRepository.GetManyAsync(u => whasapeiton.UserIds.Contains(u.Id) && !u.Borrado) : [];
        var gruposPara = whasapeiton.GroupIds != null ? await grupoRepository.GetManyAsync(g => whasapeiton.GroupIds.Contains(g.Id)) : [];
        var usuariosCc = whasapeiton.UserCcIds != null ? await usuarioRepository.GetManyAsync(u => whasapeiton.UserCcIds.Contains(u.Id) && !u.Borrado) : [];
        var gruposCc = whasapeiton.GroupCcIds != null ? await grupoRepository.GetManyAsync(u => whasapeiton.GroupCcIds.Contains(u.Id)) : [];

        destinatarios.AddRange(usuariosPara.Select(u => new DestinatarioMensaje
        {
            Id = u.Id,
            Nombre = u.NombreCompleto,
            Tipo = 1
        }));

        destinatarios.AddRange(gruposPara.Select(g => new DestinatarioMensaje
        {
            Id = g.Id,
            Nombre = g.Descripcion,
            Tipo = 2
        }));

        destinatariosCc.AddRange(usuariosCc.Select(u => new DestinatarioMensaje()
        {
            Id = u.Id,
            Nombre = u.NombreCompleto,
            Tipo = 1
        }));

        destinatariosCc.AddRange(gruposCc.Select(u => new DestinatarioMensaje()
        {
            Id = u.Id,
            Nombre = u.Descripcion,
            Tipo = 2
        }));

        var rcpt = usuariosPara.Select(u => u.Id).Union(usuariosCc.Select(uc => uc.Id))
                .Union(gruposPara.SelectMany(g => g.Usuarios.Select(gu => gu.Id)))
                .Union(gruposCc.SelectMany(gc => gc.Usuarios.Select(guc => guc.Id)))
                .Distinct().ToArray();

        var fecha = DateTime.Now;

        string para = JsonConvert.SerializeObject(destinatarios);
        string cc = JsonConvert.SerializeObject(destinatariosCc);

        mensajeRepository.AddRange(rcpt.Select(usuarioParaId => new Mensaje()
        {
            Archivado = false,
            Asunto = whasapeiton.Subject,
            ConCopia = cc,
            Cuerpo = whasapeiton.Body,
            Fecha = fecha,
            Leido = false,
            Para = para,
            Usuario_DeId = userId,
            Usuario_ParaId = usuarioParaId,
            CssClass = whasapeiton.CssClass
        }));

        mensajeEnviadoRepository.Add(new MensajeEnviado()
        {
            Asunto = whasapeiton.Subject,
            ConCopia = cc,
            Cuerpo = whasapeiton.Body,
            Fecha = fecha,
            Para = para,
            Usuario_DeId = userId
        });

        await unitOfWork.SaveChangesAsync();

        var notificacionesPorEmail = await usuarioRepository.ObtenerUsuariosConPermisoAsync(rcpt, PeitonPermission.ComunicacionesRecibirMensajesPorEmail);

        if (notificacionesPorEmail.Any())
        {
            foreach (var usuario in notificacionesPorEmail)
            {
                if (usuario.Email.StartsWith("*")) continue;

                await gmailService.EnviarMensajeAsync(usuario.Email, usuario.NombreCompleto, whasapeiton.Subject,
                    string.Format("<html><head><title>{1}</title></head><body>Este es un reenvío automático de un mensaje recibido en Peiton enviado por {2}. <strong>No responda a este correo electrónico.</strong><hr/> {0}</body></html>", whasapeiton.Body, whasapeiton.Subject, sender.NombreCompleto)
                );
            }
        }

        var ausenciaActual = await ausenciaRepository.ObtenerAusenciaActualAsync(userId);

        if (ausenciaActual != null) return; // El usuario que manda el mensaje está ausente, no le mando ningún mensaje de vuelta.

        foreach (var rcptId in rcpt)
        {
            var ausencia = await ausenciaRepository.ObtenerAusenciaActualAsync(rcptId);
            if (ausencia != null && rcptId != userId)
            {
                var lines = new List<string>()
                {
                    string.Format(ausencia.Usuario.NombreCompleto + " estará ausente hasta el próximo {0:dd/MM/yyyy}.", ausencia.FechaFin)
                };

                if (ausencia.UsuarioSuplente != null)
                {
                    lines.Add(string.Format("Para cualquier asunto laboral contacta con {0}", ausencia.UsuarioSuplente.NombreCompleto));
                }

                await this.EnviarMensajeAsync(rcptId, new Whasapeiton()
                {
                    UserIds = [userId],
                    Subject = "Fuera de la oficina - " + whasapeiton.Subject,
                    Body = string.Join("\r\n", lines)
                });
            }
        }
    }
}
