using Peiton.Contracts.TuAppoyo;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;
using Peiton.Core.Entities;
using AutoMapper;

namespace Peiton.Core.UseCases.TuAppoyo;

[Injectable]
public class GuardarConfiguracionTuAppoyoHandler(IMapper mapper, ITeAppoyoRepository teAppoyoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int tuteladoId, ConfiguracionViewModel request)
    {
        if(!await tuteladoRepository.CanModifyAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        
        var tuAppoyo = await teAppoyoRepository.GetByIdAsync(tuteladoId);

        if ( tuAppoyo == null) {
            tuAppoyo = new TeAppoyo
            {
                TuteladoId = tuteladoId
            };
            teAppoyoRepository.Add(tuAppoyo);
        }

        mapper.Map(request, tuAppoyo);

        await unitOfWork.SaveChangesAsync();
    }
}