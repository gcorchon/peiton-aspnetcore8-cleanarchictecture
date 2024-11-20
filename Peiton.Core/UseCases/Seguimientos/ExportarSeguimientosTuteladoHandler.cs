using Peiton.Contracts.Seguimientos;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Seguimientos;

[Injectable]
public class ExportarSeguimientosTuteladoHandler(IAgendaRepository agendaRepository, IPDFService pdfService)
{
    public async Task<byte[]> HandleAsync(int tuteladoId, SeguimientosFilter filter)
    {
        var seguimientos = await agendaRepository.ObtenerSeguimientosAsync(tuteladoId, filter);
        return await pdfService.RenderAsync("Views\\Seguimiento\\entradas.cshtml", seguimientos);
    }
}