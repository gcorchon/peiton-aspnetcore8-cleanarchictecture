using Peiton.Contracts.Visitas;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IRegistroEntradaVisitanteRepository : IRepository<RegistroEntradaVisitante>
{
    Task<List<Visitante>> ObtenerVisitantesAsync(string query);
}
