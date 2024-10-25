using Peiton.Contracts.GestoresAdministrativos;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionesAdministrativas;

[Injectable]
public class CrearGestionAdminisrtativaHandler(ITuteladoRepository tuteladoRepository, IUnityOfWork unityOfWork, IIdentityService identityService)
{
    public async Task HandleAsync(int tuteladoId, GuardarGestionAdministrativaRequest request)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId);
        if (tutelado == null) throw new EntityNotFoundException("Tutelado no encontrada");

        tutelado.GestionesAdministrativas.Add(new GestionAdministrativa()
        {
            UsuarioId = identityService.GetUserId(),
            FechaCreacion = DateTime.Now.Date,
            Observaciones = request.Observaciones,
            GestionAdministrativaTipoId = request.GestionAdministrativaTipoId,
            Estado = 1,
        });

        await unityOfWork.SaveChangesAsync();

    }

}
