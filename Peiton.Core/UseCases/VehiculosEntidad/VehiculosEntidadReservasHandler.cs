using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.VehiculosEntidad;

[Injectable]
public class VehiculosEntidadReservasHandler(IVehiculoEntidadReservaRepository vehiculoEntidadReservaRepository)
{
    public Task<VehiculoEntidadReserva[]> HandleAsync(DateTime fecha)
    {
        return vehiculoEntidadReservaRepository.ObtenerReservasAsync(fecha);
    }

}
