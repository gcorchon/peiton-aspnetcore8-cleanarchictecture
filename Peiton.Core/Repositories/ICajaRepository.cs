using Peiton.Contracts.Caja;
using Peiton.Core.Entities;
using Peiton.Core.Enums;

namespace Peiton.Core.Repositories
{
	public interface ICajaRepository : IRepository<Caja>
	{
		Task<List<Caja>> ObtenerMovimientosAsync(int page, int total, TipoMovimiento tipo, CajaFilter filter);
		Task<int> ContarMovimientosAsync(TipoMovimiento tipo, CajaFilter filter);
		Task<decimal> ObtenerSaldoCajaAsync(int tuteladoId);

		Task<List<Caja>> ObtenerHistoricoMovimientosAsync(int page, int total, int tuteladoId, HistoricoMovimientosFilter filter);
		Task<int> ContarHistoricoMovimientosAsync(int tuteladoId, HistoricoMovimientosFilter filter);
	}
}