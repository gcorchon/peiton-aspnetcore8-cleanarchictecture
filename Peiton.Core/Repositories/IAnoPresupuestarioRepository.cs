using Peiton.Core.Entities;

using Peiton.Contracts.AnoPresupuestario;

namespace Peiton.Core.Repositories;
public interface IAnoPresupuestarioRepository : IRepository<AnoPresupuestario>
{
    Task<int> ContarAnosPrespuestariosAsync(AnoPresupuestarioFilter filter);
    Task<List<AnoPresupuestario>> ObtenerAnosPrespuestariosAsync(int page, int total, AnoPresupuestarioFilter filter);
}
