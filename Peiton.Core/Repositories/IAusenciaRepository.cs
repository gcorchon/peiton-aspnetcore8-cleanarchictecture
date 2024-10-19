using Peiton.Contracts.Ausencias;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IAusenciaRepository : IRepository<Ausencia>
{
    Task<int> ContarAusenciasAsync(AusenciasFilter filter);
    Task<List<Ausencia>> ObtenerAusenciasAsync(int page, int total, AusenciasFilter filter);
}
