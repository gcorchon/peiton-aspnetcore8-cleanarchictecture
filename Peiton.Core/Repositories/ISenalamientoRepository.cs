using Peiton.Contracts.Senalamientos;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ISenalamientoRepository : IRepository<Senalamiento>
{
    Task<Abogado?> BuscarAbogadoDisponibleAsync(DateTime fecha);
    Task<bool> EstaLibrandoAsync(int id, DateTime fecha, int value);
    Task<bool> EstaLibrandoAsync(int id, DateTime fecha);
    Task<List<Senalamiento>> ObtenerSenalamientosAsync(SenalamientosFillter filter);
    Task<bool> TieneOtroCasoAsync(int id, DateTime fecha, int juzgadoId, int value);
    Task<bool> TieneOtroCasoAsync(int id, DateTime fecha, int juzgadoId);
}
