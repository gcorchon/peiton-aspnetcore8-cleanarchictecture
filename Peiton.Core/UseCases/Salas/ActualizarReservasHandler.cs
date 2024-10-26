using Peiton.Contracts.Salas;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Salas;

[Injectable]
public class ActualizarReservasHandler(ISalaReservaRepository salaReservaRepository, IUnitOfWork unitOfWork, IIdentityService identityService)
{
    public async Task HandleAsync(GuardarReservasRequest request)
    {
        var usuarioId = identityService.GetUserId();
        var reservas = await salaReservaRepository.GetManyAsync(r => r.UsuarioId == usuarioId);
        salaReservaRepository.RemoveRange(reservas);

        var nuevas = request.Reservas.Select(reserva => new SalaReserva()
        {
            Fecha = request.Fecha,
            Intervalo = reserva.Intervalo,
            SalaId = reserva.SalaId,
            UsuarioId = usuarioId
        });

        await salaReservaRepository.AddRangeAsync(nuevas);

        await unitOfWork.SaveChangesAsync();
    }
}