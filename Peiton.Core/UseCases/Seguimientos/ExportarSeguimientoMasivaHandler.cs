using Peiton.Contracts.Seguimientos;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Seguimientos;

[Injectable]
public class ExportarSeguimientoMasivaHandler(IAgendaRepository agendaRepository, IPDFService pdfService)
{
    public async Task<byte[]> HandleAsync(ExportarSeguimientosMasivaRequest request)
    {
        var seguimientos = await agendaRepository.ObtenerSeguimientosAsync(request);
        return await pdfService.RenderAsync("Views\\Seguimiento\\entradas.cshtml", seguimientos);
    }
}