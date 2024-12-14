using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IControlRendicionRepository))]
public class ControlRendicionRepository(PeitonDbContext dbContext) : RepositoryBase<ControlRendicion>(dbContext), IControlRendicionRepository
{
    public Task<ControlRendicion[]> ObtenerControlRendicionesAsync(int tuteladoId)
    {
        return DbSet
            .Include(c => c.Nombramiento)
            .Include(c => c.EstadoAprobacionRendicion)
            .Include(c => c.EstadoRetribucion)
            .Where(c => c.TuteladoId == tuteladoId)
            .OrderByDescending(c => c.FechaInicioRendicion ?? c.FechaInicioIncidencia)
            .AsNoTracking()
            .ToArrayAsync();

    }
}
