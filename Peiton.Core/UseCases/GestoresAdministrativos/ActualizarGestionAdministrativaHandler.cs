using Peiton.Contracts.GestoresAdministrativos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionesAdministrativas;

[Injectable]
public class ActualizarGestionAdministrativaHandler(IGestionAdministrativaRepository gestionAdministrativaRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int gestionAdministrativaId, ActualizarGestionAdministrativaRequest request)
    {
        var gestion = await gestionAdministrativaRepository.GetByIdAsync(gestionAdministrativaId);
        if (gestion == null) throw new NotFoundException("Gestión no encontrada");

        gestion.FechaSolicitud = request.FechaSolicitud;
        gestion.FechaDesignacion = request.FechaDesignacion;
        gestion.FechaFinalizacion = request.FechaFinalizacion;
        gestion.GestorAdministrativoId = request.GestorAdministrativoId;
        gestion.Importe = request.Importe;
        gestion.Estado = request.Estado;

        await unitOfWork.SaveChangesAsync();

    }

}
