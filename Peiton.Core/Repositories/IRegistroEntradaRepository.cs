using Peiton.Contracts.Visitas;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IRegistroEntradaRepository : IRepository<RegistroEntrada>
{
    Task<int> ContarRegistrosEntradaAsync(RegistroEntradaFilter filter);
    Task<int> ContarVisitasSinSalidaAsync();
    Task<RegistroEntrada[]> ObtenerRegistrosEntradaAsync(int page, int total, RegistroEntradaFilter filter);
    Task<RegistroEntrada[]> ObtenerVisitasSinSalidaAsync(int page, int total);
}
