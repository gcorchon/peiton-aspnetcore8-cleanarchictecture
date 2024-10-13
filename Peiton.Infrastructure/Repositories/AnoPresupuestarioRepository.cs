using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.AnoPresupuestario;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;
[Injectable(typeof(IAnoPresupuestarioRepository))]
public class AnoPresupuestarioRepository : RepositoryBase<AnoPresupuestario>, IAnoPresupuestarioRepository
{
    public AnoPresupuestarioRepository(PeitonDbContext dbContext) : base(dbContext)
    {

    }

    public Task<int> ContarAnosPrespuestariosAsync(AnoPresupuestarioFilter filter)
    {
        var query = ApplyFilters(this.DbSet, filter);
        return query.CountAsync();
    }

    public Task<List<AnoPresupuestario>> ObtenerAnosPrespuestariosAsync(int page, int total, AnoPresupuestarioFilter filter)
    {
        var query = ApplyFilters(this.DbSet, filter);
        return query.OrderByDescending(a => a.Ano)
             .Skip((page - 1) * total)
             .Take(total)
             .ToListAsync();
    }

    IQueryable<AnoPresupuestario> ApplyFilters(IQueryable<AnoPresupuestario> query, AnoPresupuestarioFilter? filter)
    {
        if (filter == null) return query;

        if (!string.IsNullOrWhiteSpace(filter.Descripcion))
        {
            query = query.Where(a => a.Descripcion.Contains(filter.Descripcion));
        }

        if (!string.IsNullOrWhiteSpace(filter.Ano))
        {
            query = query.Where(a => this.DbContext.IntAsString(a.Ano).StartsWith(filter.Ano));
        }

        if (!string.IsNullOrWhiteSpace(filter.SaldoInicial))
        {
            query = query.Where(a => this.DbContext.DecimalAsString(a.SaldoInicialCaja + a.SaldoInicialBanco).StartsWith(filter.SaldoInicial));
        }

        if (!string.IsNullOrWhiteSpace(filter.FechaModificacion))
        {
            query = query.Where(a => a.FechaModificacion != null && this.DbContext.DateAsString(a.FechaModificacion.Value).Contains(filter.FechaModificacion));
        }

        if (!string.IsNullOrWhiteSpace(filter.FechaBaja))
        {
            query = query.Where(a => a.FechaBaja != null && this.DbContext.DateAsString(a.FechaBaja.Value).Contains(filter.FechaBaja));
        }

        return query;
    }
}
