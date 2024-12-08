using AutoMapper;
using Newtonsoft.Json;
using Peiton.Contracts.Citas;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Citas;

[Injectable]
public class ActualizarCitaHandler(IMapper mapper, ICitaRepository citaRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork, SendPushHandler sendPush)
{
    public async Task HandleAsync(int id, ActualizarCitaRequest request)
    {
        var cita = await citaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Cita no encontrada");
        if(!await tuteladoRepository.CanModifyAsync(cita.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        
        mapper.Map(request, cita);
        await unitOfWork.SaveChangesAsync();

        await sendPush.HandleAsync(cita.TuteladoId);        
    }
}