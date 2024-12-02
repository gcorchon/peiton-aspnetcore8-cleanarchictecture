using LinqKit;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleTasacionRepository))]
public class InmuebleTasacionRepository(PeitonDbContext dbContext) : RepositoryBase<InmuebleTasacion>(dbContext), IInmuebleTasacionRepository
{
    public Task<int> ContarInmuebleTasacionesAsync(InmuebleTasacionesFilter filter)
    {
        return ApplyFilters(DbSet.Include(t => t.Inmueble)
                       .ThenInclude(i => i.Tutelado)
                       .Include(t => t.Usuario)
                       .Include(t => t.InmuebleTipoTasacion), filter)
                .CountAsync();
    }

    public Task<InmuebleTasacion[]> ObtenerInmuebleTasacionesAsync(int page, int total, InmuebleTasacionesFilter filter)
    {
        return ApplyFilters(DbSet.Include(t => t.Inmueble)
                        .ThenInclude(i => i.Tutelado)
                        .Include(t => t.Usuario)
                        .Include(t => t.InmuebleTipoTasacion), filter)
            .OrderByDescending(t => t.Id)
            .Skip((page - 1) * total)
            .Take(total)
            .AsNoTracking()
            .ToArrayAsync();
    }

    private IQueryable<InmuebleTasacion> ApplyFilters(IQueryable<InmuebleTasacion> query, InmuebleTasacionesFilter filter)
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
            query = query.Where(a => a.InmuebleTipoTasacion.Descripcion.Contains(filter.Tipo));
        }

        if (!string.IsNullOrWhiteSpace(filter.Direccion))
        {
            query = query.Where(a => a.Inmueble.DireccionCompleta!.Contains(filter.Direccion));
        }

        if (filter.Pendiente || filter.Autorizado || filter.Presentado || filter.Firme)
        {
            var predicate = PredicateBuilder.New<InmuebleTasacion>();

            if (filter.Firme) //Finalizado
            {
                predicate = predicate.Or(a => a.Firme);
            }

            if (filter.Autorizado) //Autorizado
            {
                predicate = predicate.Or(a => a.Autorizado && !a.Firme);
            }

            if (filter.Presentado) //Solicitado
            {
                predicate = predicate.Or(a => a.Presentado && !a.Autorizado && !a.Firme);
            }

            if (filter.Pendiente) //Pendiente
            {
                predicate = predicate.Or(a => !a.Autorizado && !a.Presentado && !a.Firme);
            }

            query = query.Where(predicate);
        }

        return query;

    }
}
