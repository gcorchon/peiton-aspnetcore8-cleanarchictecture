using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Autorizaciones;

[Injectable]
public class BorrarAutorizacionHandler(IAutorizacionRepository autorizacionRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var autorizacion = await autorizacionRepository.GetByIdAsync(id) ?? throw new NotFoundException("Autorizacion no encontrada");
        if(!await tuteladoRepository.CanModifyAsync(autorizacion.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        if (autorizacion.Aprobada.HasValue && autorizacion.Aprobada.Value) throw new ArgumentException("No se puede borrar una autorización ya aprobada por el tutelado");
        
        autorizacionRepository.Remove(autorizacion);
        await unitOfWork.SaveChangesAsync();
    }
}