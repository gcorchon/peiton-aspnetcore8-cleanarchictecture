using Peiton.Contracts.Caja;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class CajaPendienteTuteladoHandler(ICajaRepository cajaRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<PaginatedData<Caja>> HandleAsync(int tuteladoId, CajaPendienteTuteladoFilter filter, Pagination pagination)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        var items = await cajaRepository.ObtenerCajaPendienteTuteladoAsync(pagination.Page, pagination.Total, tuteladoId, filter);
        var total = await cajaRepository.ContarCajaPendienteTuteladoAsync(tuteladoId, filter);

        return new PaginatedData<Caja>()
        {
            Items = items,
            Total = total
        };
    }
}