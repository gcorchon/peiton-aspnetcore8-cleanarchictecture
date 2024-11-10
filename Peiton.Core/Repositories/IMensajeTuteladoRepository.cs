using Peiton.Contracts.MensajesTuAppoyo;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IMensajeTuteladoRepository : IRepository<MensajeTutelado>
{
    Task<int> ContarMensajesRecibidosAsync(MensajesTuAppoyoFilter filter);
    Task<MensajeTuAppoyoListItem[]> ObtenerMensajesRecibidosAsync(int page, int total, MensajesTuAppoyoFilter filter);
    Task<MensajeTuAppoyoEnviadoListItem[]> ObtenerMensajesEnviadosAsync(int page, int total, MensajesTuAppoyoEnviadosFilter filter);
    Task<int> ContarMensajesEnviadosAsync(MensajesTuAppoyoEnviadosFilter filter);
    Task<int> ContarMensajesSinLeerAsync();
    Task MarcarComoLeidoAsync(int id);
    Task MarcarRecibidoComoBorradoAsync(int id);
    Task MarcarRecibidosComoBorradoAsync(int[] ids);
    Task MarcarEnviadoComoBorradoAsync(int id);

}
