using Peiton.Contracts.EmergenciasCentros;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IEmergenciaCentroRepository : IRepository<EmergenciaCentro>
{
    Task<int> ContarEmergenciasCentrosAsync(int tuteladoId, EmergenciasCentrosFilter filter);
    Task<EmergenciaCentro[]> ObtenerEmergenciasCentrosAsync(int page, int total, int tuteladoId, EmergenciasCentrosFilter filter);
}
