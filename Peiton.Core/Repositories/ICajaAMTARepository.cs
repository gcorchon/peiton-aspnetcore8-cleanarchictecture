using Peiton.Core.Entities;
using Peiton.Contracts.MovimientosPendientesCaja;
using Peiton.Contracts.Caja;

namespace Peiton.Core.Repositories;
public interface ICajaAMTARepository : IRepository<CajaAMTA>
{
    Task<int> ContarMovimientosPendientesCajaAsync(MovimientosPendientesCajaFilter filter);
    Task<CajaAMTA[]> ObtenerMovimientosPendientesCajaAsync(int page, int total, MovimientosPendientesCajaFilter filter);
    Task<int> ContarCajaAMTAAsync(CajaAMTAFilter filter);
    Task<VwCajaAMTA[]> ObtenerCajaAMTAAsync(int page, int total, CajaAMTAFilter filter);
    Task<decimal> ObtenerSaldoCajaAMTAAsync();
}
