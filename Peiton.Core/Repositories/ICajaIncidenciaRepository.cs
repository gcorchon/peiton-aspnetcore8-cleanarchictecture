using Peiton.Contracts.Caja;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ICajaIncidenciaRepository : IRepository<CajaIncidencia>
{

	Task<List<CajaIncidencia>> ObtenerIncidenciasAsync(int page, int total, IncidenciasFilter filter);
	Task<int> ContarIncidenciasAsync(IncidenciasFilter filter);
}
