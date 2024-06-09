using Peiton.Contracts.Common;
using Peiton.Contracts.MovimientosPendientesBanco;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.MovimientosPendientesBanco;

[Injectable]
public class MovimientosPendientesBancoHandler(IAccountTransactionCPRepository accountTransactionCPRepository)
{    
    public async Task<PaginatedData<AccountTransactionCP>> HandleAsync(MovimientosPendientesBancoFilter filter, Pagination pagination)
    {
        var movimeintos = await accountTransactionCPRepository.ObtenerMovimientosPendientesBancoAsync(pagination.Page, pagination.Total, filter);
        var total = await accountTransactionCPRepository.ContarMovimientosPendientesBancoAsync(filter);

        return new PaginatedData<AccountTransactionCP>() {
            Items = movimeintos,
            Total = total
        };
    }
}