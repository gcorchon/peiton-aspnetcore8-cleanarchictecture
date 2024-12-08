using AutoMapper;
using Peiton.Contracts.Citas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Citas;

[Injectable]
public class CrearCitaHandler(IMapper mapper, ICitaRepository citaRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork, SendPushHandler sendPush)
{
    public async Task HandleAsync(CrearCitaRequest request)
    {       
        if(!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        
        var cita = mapper.Map(request, new Cita());
        citaRepository.Add(cita);
        await unitOfWork.SaveChangesAsync();

        await sendPush.HandleAsync(request.TuteladoId);
    }
}