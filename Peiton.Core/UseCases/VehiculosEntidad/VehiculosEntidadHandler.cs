using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.VehiculosEntidad;

[Injectable]
public class VehiculosEntidadHandler(IVehiculoEntidadRepository vehiculoEntidadRepository)
{
    public Task<VehiculoEntidad[]> HandleAsync()
    {
        return vehiculoEntidadRepository.GetAllAsync(v => v.Nombre, "asc");
    }

}
