using Peiton.Contracts.Asientos;
using Peiton.Contracts.Common;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Asientos;

[Injectable]
public class SaldosHandler(IAsientoRepository asientoRepository)
{
    public async Task<PaginatedData<Saldo>> HandleAsync(int ano, SaldosFilter filter, Pagination pagination)
    {
        var items = await asientoRepository.ObtenerSaldosAsync(pagination.Page, pagination.Total, ano, filter);
        var total = await asientoRepository.ContarSaldosAsync(ano, filter);
        return new PaginatedData<Saldo>()
        {
            Items = items,
            Total = total
        };
    }

}
