using Peiton.Contracts.Seguimientos;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IAgendaRepository : IRepository<Agenda>
{
    Task<int> ContarSeguimientosAsync(int tuteladoId, SeguimientosFilter filter);
    Task<Agenda[]> ObtenerSeguimientosAsync(int page, int total, int tuteladoId, SeguimientosFilter filter);
    Task<Agenda[]> ObtenerSeguimientosAsync(int tuteladoId, SeguimientosFilter filter);
    Task<Agenda[]> ObtenerSeguimientosAsync(ExportarSeguimientosMasivaRequest request);
}
