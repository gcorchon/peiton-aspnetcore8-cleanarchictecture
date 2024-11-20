using AutoMapper;
using Peiton.Contracts.SueldosPensiones;
using Peiton.Contracts.Tributos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tributos;

[Injectable]
public class CrearTributoHandler(IMapper mapper, ITributoTuteladoRepository tributoTuteladoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearTributoRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        var tributoTutelado = mapper.Map(request, new TributoTutelado());
        tributoTuteladoRepository.Add(tributoTutelado);
        await unitOfWork.SaveChangesAsync();
    }
}