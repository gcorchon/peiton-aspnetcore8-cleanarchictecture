using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IInmuebleAvisoRepository : IRepository<InmuebleAviso>
{
    Task<List<InmuebleAviso>> ObtenerAvisosAsync(int page, int total, InmuebleAvisosFilter filter);
    Task<int> ContarAvisosAsync(InmuebleAvisosFilter filter);
}
