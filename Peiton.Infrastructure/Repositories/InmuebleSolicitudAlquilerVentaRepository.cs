using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleSolicitudAlquilerVentaRepository))]
public class InmuebleSolicitudAlquilerVentaRepository : RepositoryBase<InmuebleSolicitudAlquilerVenta>, IInmuebleSolicitudAlquilerVentaRepository
{
    public InmuebleSolicitudAlquilerVentaRepository(PeitonDbContext dbContext) : base(dbContext)
    {

    }

    public Task<int> ContarSolicitudesAsync(InmuebleSolicitudesAlquilerVentaFilter filter)
    {
        return ApplyFilters(DbSet.Include(s => s.Inmueble).ThenInclude(i => i.Tutelado), filter)
                .CountAsync();
    }

    public Task<List<InmuebleSolicitudAlquilerVenta>> ObtenerSolicitudesAsync(int page, int total, InmuebleSolicitudesAlquilerVentaFilter filter)
    {
        return ApplyFilters(DbSet.Include(s => s.Inmueble).ThenInclude(i => i.Tutelado), filter)
                .OrderByDescending(s => s.Id)
                .Skip((page - 1) * total)
                .Take(total)
                .AsNoTracking()
                .ToListAsync();
    }

    private IQueryable<InmuebleSolicitudAlquilerVenta> ApplyFilters(IQueryable<InmuebleSolicitudAlquilerVenta> query, InmuebleSolicitudesAlquilerVentaFilter filter)
    {
        if (filter == null) return query;

        if (!string.IsNullOrWhiteSpace(filter.Id))
        {
            query = query.Where(s => DbContext.IntAsString(s.Id).StartsWith(filter.Id));
        }

        if (!string.IsNullOrWhiteSpace(filter.Direccion))
        {
            query = query.Where(s => s.Inmueble.DireccionCompleta!.Contains(filter.Direccion));
        }

        if (!string.IsNullOrWhiteSpace(filter.Tutelado))
        {
            query = query.Where(s => s.Inmueble.Tutelado.NombreCompleto!.Contains(filter.Tutelado));
        }

        if (filter.Estado.HasValue)
        {
            query = query.Where(s => s.Estado == filter.Estado);
        }

        if (!string.IsNullOrWhiteSpace(filter.Tipo))
        {
            query = query.Where(s => s.Tipo == filter.Tipo);
        }

        return query;
    }
}
