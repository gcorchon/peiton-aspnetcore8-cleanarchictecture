using AutoMapper;
using Peiton.Contracts.Vehiculos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Vehiculos;

[Injectable]
public class CrearVehiculoHandler(IMapper mapper, IVehiculoRepository vehiculoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearVehiculoRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        var vehiculo = mapper.Map(request, new Vehiculo());
        vehiculoRepository.Add(vehiculo);
        await unitOfWork.SaveChangesAsync();
    }
}