using LinqKit;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISucesionRepository))]
public class SucesionRepository(PeitonDbContext dbContext) : RepositoryBase<Sucesion>(dbContext), ISucesionRepository
{
    public Task<int> ContarSucesionesAsync(SucesionesFilter filter)
    {
        return ApplyFilters(DbSet.Include(s => s.Tutelado).Include(s => s.Usuario).Include(s => s.SucesionTipo), filter)
                .CountAsync();
    }

    public Task<Sucesion[]> ObtenerSucesionesAsync(int page, int total, SucesionesFilter filter)
    {
        return ApplyFilters(DbSet.Include(s => s.Tutelado).Include(s => s.Usuario).Include(s => s.SucesionTipo), filter)
                .OrderByDescending(s => s.Id)
                .Skip((page - 1) * total)
                .Take(total)
                .AsNoTracking()
                .ToArrayAsync();
    }

    private IQueryable<Sucesion> ApplyFilters(IQueryable<Sucesion> query, SucesionesFilter filter)
    {
        if (filter == null) return query;

        if (!string.IsNullOrWhiteSpace(filter.Id))
        {
            query = query.Where(s => DbContext.IntAsString(s.Id).StartsWith(filter.Id));
        }

        if (!string.IsNullOrWhiteSpace(filter.Nombre))
        {
            query = query.Where(s => s.Tutelado.NombreCompleto!.Contains(filter.Nombre));
        }

        if (!string.IsNullOrWhiteSpace(filter.Origen))
        {
            query = query.Where(s => s.Origen.Contains(filter.Origen));
        }

        if (!string.IsNullOrWhiteSpace(filter.Trabajador))
        {
            query = query.Where(s => s.Usuario.NombreCompleto.Contains(filter.Trabajador));
        }

        if (filter.SucesionTipoId.HasValue)
        {
            query = query.Where(s => s.SucesionTipoId == filter.SucesionTipoId.Value);
        }

        if (filter.Pendiente || filter.Autorizada || filter.Solicitada || filter.Firme)
        {
            var predicate = PredicateBuilder.New<Sucesion>();

            if (filter.Firme) //Finalizado
            {
                predicate = predicate.Or(a => a.Firme);
            }

            if (filter.Autorizada) //Autorizado
            {
                predicate = predicate.Or(a => a.Autorizada && !a.Firme);
            }

            if (filter.Solicitada) //Solicitado
            {
                predicate = predicate.Or(a => a.Solicitada && !a.Autorizada && !a.Firme);
            }

            if (filter.Pendiente) //Pendiente
            {
                predicate = predicate.Or(a => !a.Autorizada && !a.Solicitada && !a.Firme);
            }

            query = query.Where(predicate);
        }

        return query;
    }
}
