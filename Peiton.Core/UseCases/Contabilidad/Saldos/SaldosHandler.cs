using Microsoft.Extensions.Logging;
using Peiton.Contracts.Asientos;
using Peiton.Contracts.Common;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.Fondos;

[Injectable]
public class SaldosHandler(IAsientoRepository asientoRepository, ILogger<SaldosHandler> logger)
{
    public async Task<PaginatedData<Saldo>> HandleAsync(int ano, SaldosFilter filter, Pagination pagination)
    {
        var items = await asientoRepository.ObtenerSaldosAsync(pagination.Page, pagination.Total, ano, filter);
        var total = await asientoRepository.ContarSaldosAsync(ano, filter);
        logger.LogInformation("Registros {0}, Total {1}", items.Count(), total);
        return new PaginatedData<Saldo>()
        {
            Items = items,
            Total = total
        };
    }

}
