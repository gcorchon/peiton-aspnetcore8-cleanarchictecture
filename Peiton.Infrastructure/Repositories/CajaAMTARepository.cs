using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Contracts.MovimientosPendientesCaja;
using Microsoft.EntityFrameworkCore;
using Peiton.DependencyInjection;
using Peiton.Contracts.Caja;
using Microsoft.Extensions.Options;
using Peiton.Configuration;
using Microsoft.Extensions.Logging;

namespace Peiton.Infrastructure.Repositories;

[Injectable(typeof(ICajaAMTARepository))]
public class CajaAMTARepository : RepositoryBase<CajaAMTA>, ICajaAMTARepository
{

    private readonly CajaAMTASettings cajaAMTASettings;
    public CajaAMTARepository(PeitonDbContext dbContext, IOptions<CajaAMTASettings> cajaAMTAConfiguration, ILogger<CajaAMTARepository> logger) : base(dbContext)
    {
        this.cajaAMTASettings = cajaAMTAConfiguration.Value;

        logger.LogInformation(cajaAMTAConfiguration.Value.SaldoInicial.ToString());
    }

    public Task<int> ContarMovimientosPendientesCajaAsync(MovimientosPendientesCajaFilter filter)
    {
        IQueryable<CajaAMTA> query = this.DbSet
                         .Include(c => c.Tutelado);

        query = ApplyFilters(query, filter);

        return query.CountAsync();
    }

    public Task<List<CajaAMTA>> ObtenerMovimientosPendientesCajaAsync(int page, int total, MovimientosPendientesCajaFilter filter)
    {
        IQueryable<CajaAMTA> query = this.DbSet
                         .Include(c => c.Tutelado);

        query = ApplyFilters(query, filter);

        return query
                    .OrderByDescending(c => c.Fecha)
                    .Skip((page - 1) * total)
                    .Take(total)
                    .AsNoTracking()
                    .ToListAsync();
    }

    IQueryable<CajaAMTA> ApplyFilters(IQueryable<CajaAMTA> query, MovimientosPendientesCajaFilter filter)
    {
        var fechaDesde = new DateTime(2016, 1, 1);

        query = query.Where(c => c.Fecha >= fechaDesde);

        if (!string.IsNullOrWhiteSpace(filter.Fecha))
        {
            query = query.Where(c => this.DbContext.DateAsString(c.Fecha).Contains(filter.Fecha));
        }

        if (!string.IsNullOrWhiteSpace(filter.Importe))
        {
            query = query.Where(c => this.DbContext.DecimalAsString(c.Importe).StartsWith(filter.Importe));
        }

        if (!string.IsNullOrWhiteSpace(filter.Concepto))
        {
            query = query.Where(c => c.Concepto.Contains(filter.Concepto));
        }

        if (!string.IsNullOrWhiteSpace(filter.Persona))
        {
            query = query.Where(c => (c.Persona ?? "").Contains(filter.Persona) || (c.Tutelado != null && (c.Tutelado.NombreCompleto ?? "").Contains(filter.Persona)));
        }

        if (filter.Pendientes.HasValue)
        {
            if (filter.Pendientes.Value)
            {
                query = query
                    .Include(c => c.Asientos)
                    .Where(c => c.Asientos.Sum(a => a.Importe) != c.Importe);
            }
            else
            {
                query = query
                    .Include(c => c.Asientos)
                    .Where(c => c.Asientos.Sum(a => a.Importe) == c.Importe);
            }
        }

        return query;
    }

    public Task<int> ContarCajaAMTAAsync(CajaAMTAFilter filter)
    {
        return ApplyFilter(this.DbContext.VwCajaAMTA.Include(c => c.Tutelado), filter).CountAsync();
    }

    public Task<List<VwCajaAMTA>> ObtenerCajaAMTAAsync(int page, int total, CajaAMTAFilter filter)
    {
        return ApplyFilter(this.DbContext.VwCajaAMTA.Include(c => c.Tutelado), filter)
                .OrderByDescending(c => c.Id)
                .Skip((page - 1) * total)
                .Take(total)
                .AsNoTracking()
                .ToListAsync();
    }

    private IQueryable<VwCajaAMTA> ApplyFilter(IQueryable<VwCajaAMTA> query, CajaAMTAFilter filter)
    {
        if (!string.IsNullOrWhiteSpace(filter.Concepto))
        {
            query = query.Where(c => c.Concepto.Contains(filter.Concepto));
        }

        if (!string.IsNullOrWhiteSpace(filter.Persona))
        {
            query = query.Where(c => (c.Persona != null && c.Persona.Contains(filter.Persona)) || (c.Tutelado != null && c.Tutelado.NombreCompleto!.Contains(filter.Persona)));
        }

        if (!string.IsNullOrWhiteSpace(filter.Fecha))
        {
            query = query.Where(c => DbContext.DateAsString(c.Fecha).Contains(filter.Fecha));
        }

        if (!string.IsNullOrWhiteSpace(filter.Importe))
        {
            query = query.Where(c => DbContext.DecimalAsString(c.Importe).StartsWith(filter.Importe));
        }

        if (!string.IsNullOrWhiteSpace(filter.Saldo))
        {
            query = query.Where(c => DbContext.DecimalAsString(c.Saldo).StartsWith(filter.Saldo + cajaAMTASettings.SaldoInicial));
        }

        return query;
    }

    public async Task<decimal> ObtenerSaldoCajaAMTAAsync()
    {
        return await DbSet.SumAsync(c => c.Importe) + cajaAMTASettings.SaldoInicial;
    }
}




