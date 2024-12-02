using Microsoft.EntityFrameworkCore;
using Peiton.Core.Repositories;
using Peiton.Contracts.Facturas;
using Peiton.Core.Entities;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;

[Injectable(typeof(IFacturaRepository))]
public class FacturaRepository(PeitonDbContext dbContext) : RepositoryBase<Factura>(dbContext), IFacturaRepository
{
    public Task<int> ContarFacturasAsync(FacturasFilter filter)
    {
        var query = ApplyFilter(this.DbSet, filter);
        return query.CountAsync();
    }

    public Task<Factura[]> ObtenerFacturasAsync(int page, int total, FacturasFilter filter)
    {
        var query = ApplyFilter(this.DbSet, filter);
        return query.OrderByDescending(f => f.Id)
                    .Skip((page - 1) * total)
                    .Take(total)
                    .AsNoTracking()
                    .ToArrayAsync();
    }

    public Task<Factura[]> ObtenerFacturasAsync(int[] ids)
    {
        return this.DbSet
                   .Where(f => ids.Contains(f.Id))
                   .OrderByDescending(f => f.Id)
                   .AsNoTracking()
                   .ToArrayAsync();

    }

    private IQueryable<Factura> ApplyFilter(IQueryable<Factura> query, FacturasFilter filter)
    {
        if (filter == null) return query;

        if (filter.Asiento.HasValue)
        {
            if (filter.Asiento == false)
                query = query.Where(factura => factura.AsientoId == null);
            else
                query = query.Where(factura => factura.AsientoId != null);
        }

        if (!string.IsNullOrWhiteSpace(filter.Denominacion))
        {
            query = query.Where(factura => factura.Denominacion != null && factura.Denominacion.Contains(filter.Denominacion));
        }

        if (filter.EstadoContable.HasValue)
        {
            query = query.Where(factura => factura.EstadoContable == filter.EstadoContable);
        }

        if (filter.EstadoInicial.HasValue)
        {
            query = query.Where(factura => factura.EstadoInicial == filter.EstadoInicial);
        }

        if (!string.IsNullOrWhiteSpace(filter.NumeroFactura))
        {
            query = query.Where(factura => factura.NumeroFactura != null && factura.NumeroFactura.Contains(filter.NumeroFactura));
        }

        if (!string.IsNullOrWhiteSpace(filter.FechaPago))
        {
            query = query.Where(factura => factura.FechaPago != null && this.DbContext.DateAsString(factura.FechaPago.Value).Contains(filter.FechaPago));
        }

        if (!string.IsNullOrWhiteSpace(filter.FechaRegistro))
        {
            query = query.Where(factura => factura.FechaRegistro != null && this.DbContext.DateAsString(factura.FechaRegistro.Value).Contains(filter.FechaRegistro));
        }

        if (!string.IsNullOrWhiteSpace(filter.Importe))
        {
            query = query.Where(factura => factura.Importe != null && this.DbContext.DecimalAsString(factura.Importe.Value).StartsWith(filter.Importe));
        }


        return query;
    }
}
