using Peiton.Contracts.Mensajes;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IMensajeRepository : IRepository<Mensaje>
{
    Task<int> ContarMensajesAsync(MensajesFilter filter);
    Task<int> ContarMensajesSinLeerAsync();
    Task<Mensaje[]> ObtenerMensajesAsync(int page, int total, MensajesFilter filter);

}
