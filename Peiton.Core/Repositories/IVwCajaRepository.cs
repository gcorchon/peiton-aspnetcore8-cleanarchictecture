using Peiton.Core.Entities;
using Peiton.Contracts.Enums;
using Peiton.Contracts.Caja;

namespace Peiton.Core.Repositories;
public interface IVwCajaRepository : IRepository<VwCaja>
{
	Task<VwCaja[]> ObtenerCajaTuteladoAsync(int page, int total, int tuteladoId, CajaTuteladoFilter filter);
	Task<int> ContarCajaTuteladoAsync(int tuteladoId, CajaTuteladoFilter filter);
}
