using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IAccountRepository : IRepository<Account>
{
    Task<Account[]> ObtenerAccountsAsync(int tuteladoId);
    Task<Account[]> ObtenerCuentasConMovimientosAsync(int tuteladoId, DateTime desde, DateTime hasta);
    Task<Account[]> ObtenerAccountsOficinaActivasAsync(int tuteladoId, int entidadFinancieraId, string oficina);
}
