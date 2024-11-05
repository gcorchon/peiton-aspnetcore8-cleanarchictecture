using Peiton.Contracts.Mensajes;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IMensajeEnviadoRepository : IRepository<MensajeEnviado>
{
    Task<int> ContarMensajesAsync(MensajesFilter filter);
    Task<MensajeEnviado[]> ObtenerMensajesAsync(int page, int total, MensajesFilter filter);
}
