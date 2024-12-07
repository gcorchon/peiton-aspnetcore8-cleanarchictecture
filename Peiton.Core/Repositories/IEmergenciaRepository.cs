using Peiton.Contracts.Emergencias;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IEmergenciaRepository : IRepository<Emergencia>
{
    Task<int> ContarEmergenciasAsync(int tuteladoId, EmergenciasFilter filter);
    Task<Emergencia[]> ObtenerEmergenciasAsync(int page, int total, int tuteladoId, EmergenciasFilter filter);
}
