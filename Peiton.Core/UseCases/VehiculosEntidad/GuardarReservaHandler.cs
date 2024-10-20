using Peiton.Contracts.VehiculosEntidad;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.VehiculosEntidad;

[Injectable]
public class GuardarReservaHandler(IVehiculoEntidadReservaRepository vehiculoEntidadReservaRepository, IUnityOfWork unityOfWork, IIdentityService identityService)
{
    public async Task HandleAsync(GuardarReservaRequest request)
    {
        var usuarioId = identityService.GetUserId();
        var misReservasPrevias = await vehiculoEntidadReservaRepository.GetManyAsync(r => r.Fecha == request.Fecha && r.UsuarioId == usuarioId);
        vehiculoEntidadReservaRepository.RemoveRange(misReservasPrevias);

        var reservas = request.Reservas.Select(r => new VehiculoEntidadReserva()
        {
            Fecha = request.Fecha,
            Intervalo = r.Intervalo,
            UsuarioId = identityService.GetUserId(),
            VehiculoEntidadId = r.VehiculoId
        });

        vehiculoEntidadReservaRepository.AddRange(reservas);

        await unityOfWork.SaveChangesAsync();
    }
}
