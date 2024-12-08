using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Citas;

[Injectable]
public class BorrarCitaHandler(ICitaRepository citaRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var cita = await citaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Cita no encontrada");
        if(!await tuteladoRepository.CanModifyAsync(cita.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
                
        citaRepository.Remove(cita);
        await unitOfWork.SaveChangesAsync();
    }
}