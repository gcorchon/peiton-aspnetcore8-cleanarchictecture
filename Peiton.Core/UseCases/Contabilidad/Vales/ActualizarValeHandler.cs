using Peiton.Authorization;
using Peiton.Contracts.Vales;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.Vales;

[Injectable]
public class ActualizarValeHandler(IValeRepository valeRepository, IUsuarioRepository usuarioRepository, IUnityOfWork unityOfWork, IIdentityService identityService, IComunicacionesService comunicacionesService)
{
    public async Task HandleAsync(int id, ActualizarValeRequest request)
    {
        var vale = await valeRepository.GetByIdAsync(id);
        if (vale == null) throw new NotFoundException();
        vale.ObservacionesAutorizacion = request.ObservacionesAutorizacion;
        var userId = identityService.GetUserId()!.Value;

        if (await usuarioRepository.HasPermissionAsync(userId, PeitonPermission.ContabilidadValesRevisar))
        {
            if (!vale.Revisado && request.Revisado)
            {
                vale.Revisado = true;
                vale.FechaRevision = DateTime.Now.Date;
                vale.RevisorId = identityService.GetUserId();
            }
            else if (vale.Revisado && !request.Revisado)
            {
                vale.Revisado = false;
                vale.FechaRevision = null;
                vale.RevisorId = null;
            }
        }

        if (await usuarioRepository.HasPermissionAsync(userId, PeitonPermission.ContabilidadValesAutorizar))
        {
            if (!vale.Autorizado && request.Autorizado)
            {
                vale.Autorizado = true;
                vale.FechaAutorizacion = DateTime.Now.Date;
                vale.AutorizadorId = identityService.GetUserId();
            }
            else if (vale.Autorizado && !request.Autorizado)
            {
                vale.Autorizado = false;
                vale.FechaAutorizacion = null;
                vale.AutorizadorId = null;
            }
        }

        if (await usuarioRepository.HasPermissionAsync(userId, PeitonPermission.ContabilidadValesPagar))
        {
            if (!vale.Pagado && request.Pagado)
            {
                vale.Pagado = true;
                vale.FechaPago = DateTime.Now.Date;
            }
            else if (vale.Pagado && !request.Pagado)
            {
                vale.Pagado = false;
                vale.FechaPago = null;
            }
        }

        bool notificarRechazo = false;
        if (!vale.Rechazado && request.Rechazado)
        {
            vale.Rechazado = true;
            notificarRechazo = true;
        }
        else if (vale.Rechazado && !request.Rechazado)
        {
            vale.Rechazado = false;
        }

        await unityOfWork.SaveChangesAsync();

        if (notificarRechazo)
        {
            string body = string.Format(@"<p>El vale presentado el {0:dd/MM/yyyy} por un importe de {1:N2}€ ha sido rechazado.</p>
                                            <p>Observaciones: {2}</p>",
                                    vale.FechaSolicitud,
                                    vale.Importe,
                                    (vale.ObservacionesAutorizacion ?? "").Replace(Environment.NewLine, "<br />"));

            comunicacionesService.EnviarMensaje(userId, [vale.SolicitanteId], null, "Vale rechazado", body, null);
        }

    }

}
