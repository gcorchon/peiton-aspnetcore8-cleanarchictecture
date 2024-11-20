using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Seguimientos;

[Injectable]
public class ExportarSeguimientoHandler(IAgendaRepository agendaRepository, ITuteladoRepository tuteladoRepository, IPDFService pdfService)
{
    public async Task<byte[]> HandleAsync(int id)
    {
        var seguimiento = await agendaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Entrada de seguimiento no encontrada");
        if (!await tuteladoRepository.CanViewAsync(seguimiento.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        return await pdfService.RenderAsync("Views\\Seguimiento\\entrada.cshtml", seguimiento);
    }
}