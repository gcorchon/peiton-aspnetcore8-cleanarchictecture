using Azure.Core;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using System.Linq.Dynamic.Core;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleAvisoRepository))]
public class InmuebleAvisoRepository : RepositoryBase<InmuebleAviso>, IInmuebleAvisoRepository
{
    public InmuebleAvisoRepository(PeitonDbContext dbContext) : base(dbContext)
    {

    }

    public Task<int> ContarAvisosAsync(InmuebleAvisosFilter filter)
    {
        return ApplyFilters(DbSet.Include(a => a.Usuario)
                                .Include(a => a.Inmueble)
                                .ThenInclude(i => i.Tutelado)
                                .Include(a => a.InmuebleTiposAvisos)
                                .ThenInclude(t => t.TipoAviso), filter).CountAsync();
    }

    public Task<InmuebleAviso[]> ObtenerAvisosAsync(int page, int total, InmuebleAvisosFilter filter)
    {
        return ApplyFilters(DbSet.Include(a => a.Usuario)
                                .Include(a => a.Inmueble)
                                .ThenInclude(i => i.Tutelado)
                                .Include(a => a.InmuebleTiposAvisos)
                                .ThenInclude(t => t.TipoAviso), filter)
            .OrderByDescending(a => a.Id)
            .Skip((page - 1) * total)
            .Take(total)
            .AsNoTracking()
            .AsSplitQuery()
            .ToArrayAsync();
    }

    private IQueryable<InmuebleAviso> ApplyFilters(IQueryable<InmuebleAviso> query, InmuebleAvisosFilter filter)
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

        if (!string.IsNullOrWhiteSpace(filter.Direccion))
        {
            query = query.Where(a => a.Inmueble.DireccionCompleta!.Contains(filter.Direccion));
        }

        if (!string.IsNullOrWhiteSpace(filter.Tipo))
        {
            query = query.Where(a => a.InmuebleTiposAvisos.Any(t => t.TipoAviso.Descripcion.Contains(filter.Tipo)));
        }

        if (!string.IsNullOrWhiteSpace(filter.Trabajador))
        {
            query = query.Where(a => a.Usuario.Firma.Contains(filter.Trabajador));
        }

        if (filter.Pendiente || filter.EnTramite || filter.Finalizado || filter.PendientePago)
        {
            var predicate = PredicateBuilder.New<InmuebleAviso>();

            if (filter.Pendiente)
            {
                predicate = predicate.Or(a => !a.EnTramite && !a.Resuelto && !a.FechaFinalizacion.HasValue);
            }

            if (filter.EnTramite)
            {
                predicate = predicate.Or(a => a.EnTramite && !a.Resuelto && !a.FechaFinalizacion.HasValue);
            }

            if (filter.Finalizado)
            {
                predicate = predicate.Or(a => a.Resuelto);
            }

            if (filter.PendientePago)
            {
                predicate = predicate.Or(a => !a.Resuelto && a.FechaFinalizacion.HasValue);
            }

            query = query.Where(predicate);
        }

        return query;
    }
}
