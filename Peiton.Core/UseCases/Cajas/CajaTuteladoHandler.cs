using Peiton.Contracts.Caja;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class CajaTuteladoHandler(IVwCajaRepository cajaRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<PaginatedData<VwCaja>> HandleAsync(int tuteladoId, CajaTuteladoFilter filter, Pagination pagination)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        var items = await cajaRepository.ObtenerCajaTuteladoAsync(pagination.Page, pagination.Total, tuteladoId, filter);
        var total = await cajaRepository.ContarCajaTuteladoAsync(tuteladoId, filter);

        return new PaginatedData<VwCaja>()
        {
            Items = items,
            Total = total
        };
    }
}