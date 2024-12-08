using AutoMapper;
using Newtonsoft.Json;
using Peiton.Contracts.Autorizaciones;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Autorizaciones;

[Injectable]
public class ActualizarAutorizacionHandler(IMapper mapper, IAutorizacionRepository autorizacionRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork, SendPushHandler sendPush)
{
    public async Task HandleAsync(int id, ActualizarAutorizacionRequest request)
    {
        var autorizacion = await autorizacionRepository.GetByIdAsync(id) ?? throw new NotFoundException("Autorizacion no encontrada");
        if(!await tuteladoRepository.CanModifyAsync(autorizacion.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        if (autorizacion.Aprobada.HasValue && autorizacion.Aprobada.Value) throw new ArgumentException("No se puede modificar una autorización ya aprobada por el tutelado");
        
        mapper.Map(request, autorizacion);
        await unitOfWork.SaveChangesAsync();

        await sendPush.HandleAsync(autorizacion.TuteladoId);
    }
}