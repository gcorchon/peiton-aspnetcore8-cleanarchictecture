using AutoMapper;
using Peiton.Contracts.Autorizaciones;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Autorizaciones;

[Injectable]
public class CrearAutorizacionHandler(IMapper mapper, IAutorizacionRepository autorizacionRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork, SendPushHandler sendPush)
{
    public async Task HandleAsync(CrearAutorizacionRequest request)
    {        
        if(!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        
        var autorizacion = mapper.Map(request, new Autorizacion());
        autorizacionRepository.Add(autorizacion);
        await unitOfWork.SaveChangesAsync();

        await sendPush.HandleAsync(request.TuteladoId);
    }
}