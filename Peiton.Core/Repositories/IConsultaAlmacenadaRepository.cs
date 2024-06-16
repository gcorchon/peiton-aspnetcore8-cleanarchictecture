using Peiton.Contracts.Consultas;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories
{
    public interface IConsultaAlmacenadaRepository : IRepository<ConsultaAlmacenada>
    {
        Task<List<ConsultaListItem>> ObtenerConsultas(int usuarioId, ConsultasFilter filter);
    }
}