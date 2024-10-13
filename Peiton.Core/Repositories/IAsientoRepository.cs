using Peiton.Contracts.Asientos;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IAsientoRepository : IRepository<Asiento>
{
    Task<int> ContarAsientosAsync(AsientosFilter filter);
    Task<int> ContarAsientosHuerfanosAsync(AsientosHuerfanosFilter filter);
    Task<List<Asiento>> ObtenerAsientosAsync(int page, int total, AsientosFilter filter);
    Task<List<Asiento>> ObtenerAsientosHuerfanosAsync(int page, int total, AsientosHuerfanosFilter filter);
    Task<int> ObtenerUltimoNumeroAsientoAsync(int ano);
    Task<List<FondoListItem>> ObtenerFondoAsync(int page, int total, FondosFilter filter, IEnumerable<CapituloPartidaFilter> partidas);
    Task<int> ContarFondoAsync(FondosFilter filter, IEnumerable<CapituloPartidaFilter> partidas);
    Task<decimal> ObtenerDiferenciaFondoAsync(FondosFilter filter, IEnumerable<CapituloPartidaFilter> partidas);
    Task<IEnumerable<Saldo>> ObtenerSaldosAsync(int page, int total, int ano, SaldosFilter filter);
    Task<int> ContarSaldosAsync(int ano, SaldosFilter filter);
}
