using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Asientos;

[Injectable]
public class AsientosFondoTuteladoHandler(IAsientoRepository Repository, ITuteladoRepository tuteladoRepository)
{
    public async Task<PaginatedData<Asiento>> HandleAsync(int tuteladoId, Pagination pagination)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        var items = await Repository.ObtenerAsientosFondoTuteladoAsync(pagination.Page, pagination.Total, tuteladoId);
        var total = await Repository.ContarAsientosFondoTuteladoAsync(tuteladoId);

        return new PaginatedData<Asiento>()
        {
            Items = items,
            Total = total
        };
    }
}