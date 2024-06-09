using Peiton.Contracts.Asientos;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories
{
    public interface IAsientoRepository : IRepository<Asiento>
    {
        Task<int> ContarAsientosAsync(AsientosFilter filter);
        Task<int> ContarAsientosHuerfanosAsync(AsientosHuerfanosFilter filter);
        Task<List<Asiento>> ObtenerAsientosAsync(int page, int total, AsientosFilter filter);
        Task<List<Asiento>> ObtenerAsientosHuerfanosAsync(int page, int total, AsientosHuerfanosFilter filter);
        Task<int> ObtenerUltimoNumeroAsientoAsync(int ano);
    }
}