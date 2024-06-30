using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories
{
    public interface IInmuebleTasacionRepository : IRepository<InmuebleTasacion>
    {
        Task<int> ContarInmuebleTasacionesAsync(InmuebleTasacionesFilter filter);
        Task<List<InmuebleTasacion>> ObtenerInmuebleTasacionesAsync(int page, int total, InmuebleTasacionesFilter filter);
    }
}