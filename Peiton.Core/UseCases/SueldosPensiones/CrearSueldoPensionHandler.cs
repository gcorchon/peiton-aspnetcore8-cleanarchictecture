using AutoMapper;
using Peiton.Contracts.SueldosPensiones;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.SueldosPensiones;

[Injectable]
public class CrearSueldoPensionHandler(IMapper mapper, ISueldoPensionRepository sueldoPensionRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearSueldoPensionRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        var sueldoPension = mapper.Map(request, new SueldoPension());
        sueldoPensionRepository.Add(sueldoPension);
        await unitOfWork.SaveChangesAsync();
    }
}