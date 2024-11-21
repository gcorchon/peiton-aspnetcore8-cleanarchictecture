using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tareas;

[Injectable]
public class ExportarTareaHandler(ITareaRepository agendaRepository, ITuteladoRepository tuteladoRepository, IPDFService pdfService)
{
    public async Task<byte[]> HandleAsync(int id)
    {
        var tarea = await agendaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Tarea no encontrada");
        if (!await tuteladoRepository.CanViewAsync(tarea.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        return await pdfService.RenderAsync("Views\\Tareas\\entrada.cshtml", tarea);
    }
}