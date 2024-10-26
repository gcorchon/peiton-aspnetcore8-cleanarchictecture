using Peiton.Contracts.Salas;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Salas;

[Injectable]
public class ReservasHandler(ISalaReservaRepository salaReservaRepository)
{
    public async Task<List<SalaReserva>> HandleAsync(DateTime fecha)
    {
        return await salaReservaRepository.ObtenerReservasAsync(fecha);
    }
}