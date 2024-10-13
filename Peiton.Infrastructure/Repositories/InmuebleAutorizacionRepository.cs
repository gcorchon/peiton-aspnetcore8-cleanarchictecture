using LinqKit;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleAutorizacionRepository))]
public class InmuebleAutorizacionRepository : RepositoryBase<InmuebleAutorizacion>, IInmuebleAutorizacionRepository
{
    public InmuebleAutorizacionRepository(PeitonDbContext dbContext) : base(dbContext)
    {

    }

    public Task<int> ContarAutorizacionesAsync(InmuebleAutorizacionesFilter filter)
    {
        return ApplyFilters(DbSet.Include(a => a.Inmueble)
                                 .ThenInclude(i => i.Tutelado)
                                 .Include(a => a.Usuario)
                                 .Include(a => a.InmuebleMotivoAutorizacion)
                                 .ThenInclude(i => i.InmuebleTipoAutorizacion), filter)
                .CountAsync();
    }

    public Task<List<InmuebleAutorizacion>> ObtenerAutorizacionesAsync(int page, int total, InmuebleAutorizacionesFilter filter)
    {
        return ApplyFilters(DbSet.Include(a => a.Inmueble)
                                 .ThenInclude(i => i.Tutelado)
                                 .Include(a => a.Usuario)
                                 .Include(a => a.InmuebleMotivoAutorizacion)
                                 .ThenInclude(i => i.InmuebleTipoAutorizacion), filter)
                .OrderByDescending(a => a.Id)
                .Skip((page - 1) * total)
                .Take(total)
                .AsNoTracking()
                .ToListAsync();
    }

    private IQueryable<InmuebleAutorizacion> ApplyFilters(IQueryable<InmuebleAutorizacion> query, InmuebleAutorizacionesFilter filter)
    {
        if (filter == null) return query;

        if (!string.IsNullOrWhiteSpace(filter.Id))
        {
            query = query.Where(a => DbContext.IntAsString(a.Id).StartsWith(filter.Id));
        }

        if (!string.IsNullOrWhiteSpace(filter.Nombre))
        {
            query = query.Where(a => a.Inmueble.Tutelado.NombreCompleto!.Contains(filter.Nombre));
        }

        if (!string.IsNullOrWhiteSpace(filter.Trabajador))
        {
            query = query.Where(a => a.Usuario.Firma.Contains(filter.Trabajador));
        }

        if (!string.IsNullOrWhiteSpace(filter.Tipo))
        {
            query = query.Where(a => a.InmuebleMotivoAutorizacion.InmuebleTipoAutorizacion.Descripcion.Contains(filter.Tipo));
        }

        if (!string.IsNullOrWhiteSpace(filter.Direccion))
        {
            query = query.Where(a => a.Inmueble.DireccionCompleta!.Contains(filter.Direccion));
        }

        if (filter.Archivo.HasValue)
        {
            query = query.Where(a => a.Archivo == filter.Archivo.Value);
        }

        if (filter.Pendiente || filter.Autorizado || filter.Presentado || filter.Firme)
        {
            var predicate = PredicateBuilder.New<InmuebleAutorizacion>();

            if (filter.Pendiente)
            {
                predicate = predicate.Or(a => !a.Autorizado && !a.Presentado && !a.Firme);
            }

            if (filter.Autorizado)
            {
                predicate = predicate.Or(a => a.Autorizado && !a.Presentado && !a.Firme);
            }

            if (filter.Presentado)
            {
                predicate = predicate.Or(a => a.Presentado && !a.Firme);
            }

            if (filter.Firme)
            {
                predicate = predicate.Or(a => a.Firme);
            }

            query = query.Where(predicate);
        }

        return query;
    }
}
