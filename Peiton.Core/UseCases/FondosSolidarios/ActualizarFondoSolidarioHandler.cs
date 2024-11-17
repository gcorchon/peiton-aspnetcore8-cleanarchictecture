using Peiton.Authorization;
using Peiton.Contracts.FondosSolidarios;
using Peiton.Contracts.Mensajes;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.FondosSolidarios;

[Injectable]
public class ActualizarFondoSolidarioHandler(IFondoSolidarioRepository fondoSolidarioRepository, ITuteladoRepository tuteladoRepository, IIdentityService identityService, IComunicacionesService comunicacionesService, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ActualizarFondoSolidarioRequest request)
    {
        var fondoSolidario = await fondoSolidarioRepository.GetByIdAsync(id) ?? throw new NotFoundException("Fondo solidario no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(fondoSolidario.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar los datos del tutelado");

        fondoSolidario.ObservacionesAutorizacion = request.ObservacionesAutorizacion;

        var userId = identityService.GetUserId();

        if (await identityService.HasPermissionAsync(PeitonPermission.GestionMasivaFondoSolidarioVerificar))
        {
            if (!fondoSolidario.Verificado && request.Verificado)
            {
                fondoSolidario.Verificado = true;
                fondoSolidario.VerificadorId = userId;
                fondoSolidario.FechaVerificacion = DateTime.Now;
            }
            else if (fondoSolidario.Verificado && !request.Verificado)
            {
                fondoSolidario.Verificado = false;
                fondoSolidario.VerificadorId = null;
                fondoSolidario.FechaVerificacion = null;
            }
        }

        if (await identityService.HasPermissionAsync(PeitonPermission.GestionMasivaFondoSolidarioRevisar))
        {
            if (!fondoSolidario.Revisado && request.Revisado)
            {
                fondoSolidario.Revisado = true;
                fondoSolidario.FechaRevision = DateTime.Now.Date;
                fondoSolidario.RevisorId = userId;
            }
            else if (fondoSolidario.Revisado && !request.Revisado)
            {
                fondoSolidario.Revisado = false;
                fondoSolidario.FechaRevision = null;
                fondoSolidario.RevisorId = null;
            }
        }

        if (await identityService.HasPermissionAsync(PeitonPermission.GestionMasivaFondoSolidarioAutorizarTodo) || (fondoSolidario.Importe <= 500 && await identityService.HasPermissionAsync(PeitonPermission.GestionMasivaFondoSolidarioAutorizarParcial)))
        {
            if (!fondoSolidario.Autorizado && request.Autorizado)
            {
                fondoSolidario.Autorizado = true;
                fondoSolidario.FechaAutorizacion = DateTime.Now.Date;
                fondoSolidario.AutorizadorId = userId;
            }
            else if (fondoSolidario.Autorizado && !request.Autorizado)
            {
                fondoSolidario.Autorizado = false;
                fondoSolidario.FechaAutorizacion = null;
                fondoSolidario.AutorizadorId = null;
            }
        }

        if (await identityService.HasPermissionAsync(PeitonPermission.GestionMasivaFondoSolidarioPagar))
        {
            fondoSolidario.FechaPago = request.FechaPago;
            fondoSolidario.FechaBaja = request.FechaBaja;

            fondoSolidario.FondoSolidarioFormaPagoId = request.FondoSolidarioFormaPagoId;
            fondoSolidario.FondoSolidarioTarjetaPrepagoId = request.FondoSolidarioTarjetaPrepagoId;
            if (!fondoSolidario.Pagado && request.Pagado)
            {
                fondoSolidario.Pagado = true;
                fondoSolidario.PagadorId = userId;

            }
            else if (fondoSolidario.Pagado && !request.Pagado)
            {
                fondoSolidario.Pagado = false;
                fondoSolidario.PagadorId = null;
            }
        }


        bool notificarRechazo = false;
        if (!fondoSolidario.Rechazado && request.Rechazado)
        {
            fondoSolidario.Rechazado = true;
            notificarRechazo = true;
        }
        else if (fondoSolidario.Rechazado && !request.Rechazado)
        {
            fondoSolidario.Rechazado = false;
        }

        await unitOfWork.SaveChangesAsync();

        if (notificarRechazo)
        {
            string body = string.Format(@"<p>El Fondo Solidario presentado el {0:dd/MM/yyyy} por un importe de {1:N2}€ para {2} ha sido rechazado.</p>
                                        <p>Observaciones: {2}</p>",
                                    fondoSolidario.FechaSolicitud,
                                    fondoSolidario.Importe,
                                    (fondoSolidario.ObservacionesAutorizacion ?? "").Replace(Environment.NewLine, "<br />"), fondoSolidario.Tutelado.NombreCompleto);

            await comunicacionesService.EnviarMensajeAsync(new Whasapeiton()
            {
                UserIds = [fondoSolidario.SolicitanteId],
                Subject = "Fondo Solidario rechazado",
                Body = body
            });
        }

    }
}