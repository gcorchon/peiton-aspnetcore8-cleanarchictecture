using Peiton.Contracts.Ausencias;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IAusenciaRepository : IRepository<Ausencia>
{
    Task<int> ContarAusenciasAsync(AusenciasFilter filter);
    Task<Ausencia?> ObtenerAusenciaActualAsync(int userId);
    Task<Ausencia[]> ObtenerAusenciasAsync(int page, int total, AusenciasFilter filter);
}
