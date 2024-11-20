using Peiton.Contracts.Common;
using Peiton.Contracts.Seguimientos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Seguimientos;

[Injectable]
public class SeguimientosHandler(IAgendaRepository agendaRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<PaginatedData<Agenda>> HandleAsync(int tuteladoId, SeguimientosFilter filter, Pagination pagination)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        var items = await agendaRepository.ObtenerSeguimientosAsync(pagination.Page, pagination.Total, tuteladoId, filter);
        var total = await agendaRepository.ContarSeguimientosAsync(tuteladoId, filter);

        return new PaginatedData<Agenda>()
        {
            Items = items,
            Total = total
        };
    }
}