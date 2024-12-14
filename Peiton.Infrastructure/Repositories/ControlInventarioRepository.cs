using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;

[Injectable(typeof(IControlInventarioRepository))]
public class ControlInventarioRepository(PeitonDbContext dbContext) : RepositoryBase<ControlInventario>(dbContext), IControlInventarioRepository
{
    public Task<ControlInventario[]> ObtenerControlInventariosAsync(int tuteladoId)
    {
        return DbSet.Include(c => c.EstadoInventario)
                    .Include(c => c.EstadoAprobacionInventario)
                    .Include(c => c.Nombramiento)
                    .Where(c => c.TuteladoId == tuteladoId)
                    .OrderByDescending(c => c.FechaSalida)
                    .AsNoTracking()
                    .ToArrayAsync();
    }
}
