using Peiton.Core.Entities;


using Peiton.Contracts.MovimientosPendientesBanco;

namespace Peiton.Core.Repositories;
public interface IAccountTransactionCPRepository : IRepository<AccountTransactionCP>
{
    Task<int> ContarMovimientosPendientesBancoAsync(MovimientosPendientesBancoFilter filter);
    Task<AccountTransactionCP[]> ObtenerMovimientosPendientesBancoAsync(int page, int total, MovimientosPendientesBancoFilter filter);
}
