using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tareas;

[Injectable]
public class CerrarTareaHandler(ITareaRepository tareaRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var tarea = await tareaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Tarea no encontrada");
        if (!await tuteladoRepository.CanModifyAsync(id)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        tarea.FechaCierre = DateTime.Now;
        await unitOfWork.SaveChangesAsync();
    }
}