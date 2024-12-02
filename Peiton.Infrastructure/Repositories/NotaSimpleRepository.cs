using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(INotaSimpleRepository))]
public class NotaSimpleRepository(PeitonDbContext dbContext) : RepositoryBase<NotaSimple>(dbContext), INotaSimpleRepository
{
    public Task<int> ContarNotasSimplesAsync(NotasSimplesFilter filter)
    {
        return ApplyFilters(DbSet.Include(a => a.Tutelado)
                                 .Include(a => a.Usuario)
                                 .Include(a => a.Inmueble)
                                 .Include(a => a.CausaNotaSimple), filter)
               .CountAsync();
    }

    public Task<NotaSimple[]> ObtenerNotasSimplesAsync(int page, int total, NotasSimplesFilter filter)
    {
        return ApplyFilters(DbSet.Include(a => a.Tutelado).Include(a => a.Usuario).Include(a => a.Inmueble).Include(a => a.CausaNotaSimple), filter)
            .OrderByDescending(a => a.Id)
            .Skip((page - 1) * total)
            .Take(total)
            .AsNoTracking()
            .ToArrayAsync();
    }

    private IQueryable<NotaSimple> ApplyFilters(IQueryable<NotaSimple> query, NotasSimplesFilter filter)
    {
        if (filter == null) return query;

        if (!string.IsNullOrWhiteSpace(filter.Id))
        {
            query = query.Where(n => DbContext.IntAsString(n.Id).StartsWith(filter.Id));
        }

        if (!string.IsNullOrWhiteSpace(filter.Fecha))
        {
            query = query.Where(n => DbContext.DateAsString(n.Fecha).Contains(filter.Fecha));
        }

        if (!string.IsNullOrWhiteSpace(filter.Nombre))
        {
            query = query.Where(n => n.Tutelado.NombreCompleto!.Contains(filter.Nombre));
        }

        if (!string.IsNullOrWhiteSpace(filter.Texto))
        {
            query = query.Where(n => n.Descripcion.Contains(filter.Texto)
                                || (n.Inmueble != null && n.Inmueble.DireccionCompleta!.Contains(filter.Texto))
                                || n.Usuario!.NombreCompleto.Contains(filter.Texto));
        }

        if (filter.CausaId.HasValue)
        {
            query = query.Where(n => n.CausaNotaSimpleId == filter.CausaId.Value);
        }

        if (filter.Finalizado.HasValue)
        {
            query = query.Where(n => n.Finalizado == filter.Finalizado.Value);
        }

        return query;
    }
}
