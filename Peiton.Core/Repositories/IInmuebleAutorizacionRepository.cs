using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IInmuebleAutorizacionRepository : IRepository<InmuebleAutorizacion>
{
    Task<int> ContarAutorizacionesAsync(InmuebleAutorizacionesFilter filter);
    Task<List<InmuebleAutorizacion>> ObtenerAutorizacionesAsync(int page, int total, InmuebleAutorizacionesFilter filter);
}
