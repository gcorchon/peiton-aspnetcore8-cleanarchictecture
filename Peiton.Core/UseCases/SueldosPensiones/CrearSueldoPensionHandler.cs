using AutoMapper;
using Peiton.Contracts.SueldosPensiones;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.SueldosPensiones;

[Injectable]
public class CrearSueldoPensionHandler(IMapper mapper, ISueldoPensionRepository sueldoPensionRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearSueldoPensionRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");

        var sueldoPension = mapper.Map(request, new SueldoPension());
        sueldoPensionRepository.Add(sueldoPension);
        await unitOfWork.SaveChangesAsync();
    }
}