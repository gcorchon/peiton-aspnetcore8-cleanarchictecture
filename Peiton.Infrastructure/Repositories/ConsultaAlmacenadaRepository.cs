using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Consultas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IConsultaAlmacenadaRepository))]
public class ConsultaAlmacenadaRepository : RepositoryBase<ConsultaAlmacenada>, IConsultaAlmacenadaRepository
{
    public ConsultaAlmacenadaRepository(PeitonDbContext dbContext) : base(dbContext)
    {

    }

    public Task<List<ConsultaListItem>> ObtenerConsultasAsync(int usuarioId, ConsultasFilter filter)
    {
        return ApplyFilters(DbContext.ObtenerConsultasAlmacenadas(usuarioId), filter)
                .OrderBy(c => c.Descripcion)
                .AsNoTracking()
                .ToListAsync();
    }

    public Task<bool> PuedeEjecutarConsultaAsync(int id, int usuarioId)
    {
        return this.DbSet.Include(c => c.Usuarios)
                         .Include(c => c.Grupos)
                         .ThenInclude(g => g.Usuarios)
                         .Where(c => c.Id == id && (c.Usuarios.Any(u => u.Id == usuarioId) || c.Grupos.SelectMany(g => g.Usuarios).Any(u => u.Id == usuarioId)))
                         .AnyAsync();
    }

    private IQueryable<ConsultaListItem> ApplyFilters(IQueryable<ConsultaListItem> query, ConsultasFilter filter)
    {
        if (filter == null) return query;

        if (!string.IsNullOrEmpty(filter.Id))
        {
            query = query.Where(c => DbContext.IntAsString(c.Id).StartsWith(filter.Id));
        }

        if (!string.IsNullOrEmpty(filter.Descripcion))
        {
            query = query.Where(c => c.Descripcion.Contains(filter.Descripcion));
        }

        if (!string.IsNullOrEmpty(filter.Categoria))
        {
            query = query.Where(c => c.Categoria.Contains(filter.Categoria));
        }

        if (!string.IsNullOrEmpty(filter.Usuarios))
        {
            query = query.Where(c => c.Usuarios != null && c.Usuarios.Contains(filter.Usuarios));
        }

        return query;
    }
}
