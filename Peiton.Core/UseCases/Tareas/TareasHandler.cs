using Peiton.Contracts.Common;
using Peiton.Contracts.Tareas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tareas;

[Injectable]
public class TareasHandler(ITareaRepository tareaRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<PaginatedData<Tarea>> HandleAsync(int tuteladoId, TareasFilter filter, Pagination pagination)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        var items = await tareaRepository.ObtenerTareasAsync(pagination.Page, pagination.Total, tuteladoId, filter);
        var total = await tareaRepository.ContarTareasAsync(tuteladoId, filter);

        return new PaginatedData<Tarea>()
        {
            Items = items,
            Total = total
        };
    }
}