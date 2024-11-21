using Peiton.Contracts.Tareas;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tareas;

[Injectable]
public class TareaHandler(ITareaRepository agendaRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<Tarea> HandleAsync(int id)
    {
        var tarea = await agendaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Entrada de tarea no encontrada");
        if (!await tuteladoRepository.CanViewAsync(tarea.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        return tarea;
    }
}