using Peiton.Authorization;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Mensajes;

[Injectable]
public class ContarPendientesGeneralHandler(IMensajeRepository mensajeRepository, IMensajeTuteladoRepository mensajeTuteladoRepository, IUsuarioRepository usuarioRepository)
{
    public async Task<int> HandleAsync()
    {
        var total = await mensajeRepository.ContarMensajesSinLeerAsync();

        var hasTuAppoyoPermission = await usuarioRepository.HasPermissionAsync(PeitonPermission.ComunicacionesMensajesTuAppoyo);

        if (hasTuAppoyoPermission)
        {
            var totalTuAppoyo = await mensajeTuteladoRepository.ContarMensajesSinLeerAsync();
            total += totalTuAppoyo;
        }

        return total;
    }
}