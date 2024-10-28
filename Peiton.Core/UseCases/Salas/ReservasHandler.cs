using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Salas;

[Injectable]
public class ReservasHandler(ISalaReservaRepository salaReservaRepository)
{
    public async Task<SalaReserva[]> HandleAsync(DateTime fecha)
    {
        return await salaReservaRepository.ObtenerReservasAsync(fecha);
    }
}