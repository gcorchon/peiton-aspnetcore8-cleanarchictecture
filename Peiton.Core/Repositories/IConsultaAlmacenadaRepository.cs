using Peiton.Contracts.Consultas;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories
{
    public interface IConsultaAlmacenadaRepository : IRepository<ConsultaAlmacenada>
    {
        Task<List<ConsultaListItem>> ObtenerConsultasAsync(int usuarioId, ConsultasFilter filter);

        Task<bool> PuedeEjecutarConsultaAsync(int id, int usuarioId);
    }
}