using AutoMapper;
using Peiton.Contracts.Vehiculos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Vehiculos;

[Injectable]
public class ActualizarVehiculoHandler(IMapper mapper, IVehiculoRepository vehiculoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ActualizarVehiculoRequest request)
    {
        var vehiculo = await vehiculoRepository.GetByIdAsync(id);
        if (vehiculo == null) throw new NotFoundException("Sueldo o pensión no encontrada");

        if (!await tuteladoRepository.CanModifyAsync(vehiculo.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");

        mapper.Map(request, vehiculo);

        await unitOfWork.SaveChangesAsync();
    }
}