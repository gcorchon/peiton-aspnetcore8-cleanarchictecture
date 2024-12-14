using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IControlCuentaGeneralRepository))]
public class ControlCuentaGeneralRepository(PeitonDbContext dbContext) : RepositoryBase<ControlCuentaGeneral>(dbContext), IControlCuentaGeneralRepository
{
    public Task<ControlCuentaGeneral[]> ObtenerControlCuentasGeneralesAsync(int tuteladoId)
    {
        return DbSet
                .Include(c => c.TipoCGJ)
                .Include(c => c.EstadoAprobacionCGJ)
                .Include(c => c.NombramientoPresentada)
                .Include(c => c.NombramientoArchivado)
                .Where(c => c.TuteladoId == tuteladoId)
                .OrderByDescending(c => c.FechaInicioPresentada ?? c.FechaArchivado)
                .AsNoTracking()
                .ToArrayAsync();
    }
}
