using AutoMapper;
using Peiton.Contracts.SueldosPensiones;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.SueldosPensiones;

[Injectable]
public class ActualizarSueldoPensionHandler(IMapper mapper, ISueldoPensionRepository sueldoPensionRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ActualizarSueldoPensionRequest request)
    {
        var sueldoPension = await sueldoPensionRepository.GetByIdAsync(id);
        if (sueldoPension == null) throw new EntityNotFoundException("Sueldo o pensión no encontrada");

        if (!await tuteladoRepository.CanModifyAsync(sueldoPension.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");

        mapper.Map(request, sueldoPension);

        await unitOfWork.SaveChangesAsync();
    }
}