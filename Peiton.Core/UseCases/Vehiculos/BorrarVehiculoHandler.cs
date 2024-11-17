using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Vehiculos;

[Injectable]
public class BorrarVehiculoHandler(IVehiculoRepository vehiculoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var vehiculo = await vehiculoRepository.GetByIdAsync(id);
        if (vehiculo == null) throw new NotFoundException("Sueldo o pensión no encontrada");

        if (!await tuteladoRepository.CanModifyAsync(vehiculo.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");
        vehiculoRepository.Remove(vehiculo);
        await unitOfWork.SaveChangesAsync();
    }
}