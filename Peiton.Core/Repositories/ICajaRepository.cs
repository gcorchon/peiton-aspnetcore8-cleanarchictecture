using Peiton.Core.Entities;
using Peiton.Contracts.Enums;
using Peiton.Contracts.Caja;

namespace Peiton.Core.Repositories;
public interface ICajaRepository : IRepository<Caja>
{
	Task<List<Caja>> ObtenerMovimientosAsync(int page, int total, TipoMovimiento tipo, CajaFilter filter);
	Task<int> ContarMovimientosAsync(TipoMovimiento tipo, CajaFilter filter);
	Task<decimal> ObtenerSaldoCajaAsync(int tuteladoId);
	Task<decimal> ObtenerSaldoCajaAsync();
	Task<List<Caja>> ObtenerHistoricoMovimientosAsync(int page, int total, int tuteladoId, HistoricoMovimientosFilter filter);
	Task<int> ContarHistoricoMovimientosAsync(int tuteladoId, HistoricoMovimientosFilter filter);
	Task<List<Reintegro>> ObtenerReintegrosParaDocumento(DateTime fechaDesde, DateTime fechaHasta);
}
