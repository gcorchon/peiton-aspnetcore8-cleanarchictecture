using Microsoft.EntityFrameworkCore;
using Peiton.Core.Repositories;
using Peiton.Contracts.Asientos;
using Peiton.Core.Entities;
using Peiton.DependencyInjection;
using System.Linq.Expressions;
using Dapper;

namespace Peiton.Infrastructure.Repositories;
[Injectable(typeof(IAsientoRepository))]
public class AsientoRepository : RepositoryBase<Asiento>, IAsientoRepository
{
    public AsientoRepository(PeitonDbContext dbContext) : base(dbContext)
    {

    }

    public Task<int> ContarAsientosAsync(AsientosFilter filter)
    {
        var query = ApplyFilters(this.DbSet.Include(a => a.Partida).ThenInclude(b => b!.Capitulo), filter);
        return query.CountAsync();
    }

    public Task<Asiento[]> ObtenerAsientosAsync(int page, int total, AsientosFilter filter)
    {
        var query = ApplyFilters(this.DbSet.Include(a => a.Partida).ThenInclude(b => b!.Capitulo), filter);
        return query.OrderByDescending(asiento => asiento.Id)
             .Skip((page - 1) * total)
             .Take(total)
             .AsNoTracking()
             .ToArrayAsync();
    }

    public Task<int> ContarAsientosHuerfanosAsync(AsientosHuerfanosFilter filter)
    {
        var query = ApplyFiltersAsientosHuerfanos(this.DbSet.Include(a => a.Partida).ThenInclude(b => b!.Capitulo), filter);
        return query.CountAsync();
    }

    public Task<Asiento[]> ObtenerAsientosHuerfanosAsync(int page, int total, AsientosHuerfanosFilter filter)
    {
        var query = ApplyFiltersAsientosHuerfanos(this.DbSet.Include(a => a.Partida).ThenInclude(b => b!.Capitulo), filter);
        return query.OrderByDescending(asiento => asiento.Id)
             .Skip((page - 1) * total)
             .Take(total)
             .AsNoTracking()
             .ToArrayAsync();
    }

    public Task<int> ObtenerUltimoNumeroAsientoAsync(int ano)
    {
        return DbContext.Database.SqlQuery<int>($"select coalesce(max(Numero), 0) as Value from Asiento where YEAR(FechaAutorizacion) = {ano}").FirstAsync();
    }

    private IQueryable<Asiento> ApplyFilters(IQueryable<Asiento> query, AsientosFilter filter)
    {
        if (filter == null) return query;

        if (!string.IsNullOrWhiteSpace(filter.Capitulo))
        {
            query = query.Where(asiento => asiento.Partida!.Capitulo!.Descripcion.StartsWith(filter.Capitulo));
        }

        if (!string.IsNullOrWhiteSpace(filter.Partida))
        {
            query = query.Where(asiento => asiento.Partida!.Descripcion.StartsWith(filter.Partida));
        }

        if (!string.IsNullOrWhiteSpace(filter.Numero))
        {
            query = query.Where(asiento => asiento.Numero != null && DbContext.IntAsString(asiento.Numero.Value).StartsWith(filter.Numero));
        }

        if (!string.IsNullOrWhiteSpace(filter.Tipo))
        {
            if (string.Equals(filter.Tipo, "C", StringComparison.InvariantCultureIgnoreCase))
            {
                query = query.Where(asiento => asiento.CajaAMTAId != null);
            }
            else if (string.Equals(filter.Tipo, "B", StringComparison.InvariantCultureIgnoreCase))
            {
                query = query.Where(asiento => asiento.AccountTransactionCPId != null);
            }
            else
            {
                query = query.Where(asiento => false);
            }
        }

        if (!string.IsNullOrWhiteSpace(filter.IngresoGasto))
        {
            if (string.Equals(filter.Tipo, "I", StringComparison.InvariantCultureIgnoreCase))
            {
                query = query.Where(asiento => asiento.TipoMovimiento == 2);
            }
            else if (string.Equals(filter.Tipo, "G", StringComparison.InvariantCultureIgnoreCase))
            {
                query = query.Where(asiento => asiento.TipoMovimiento == 1);
            }
            else
            {
                query = query.Where(asiento => false);
            }
        }

        if (!string.IsNullOrWhiteSpace(filter.Concepto))
        {
            query = query.Where(asiento => asiento.Concepto != null && asiento.Concepto.Contains(filter.Concepto));
        }

        if (!string.IsNullOrEmpty(filter.Importe))
        {
            query = query.Where(asiento => DbContext.DecimalAsString(asiento.Importe).StartsWith(filter.Importe));
        }

        if (!string.IsNullOrWhiteSpace(filter.FechaAutorizacion))
        {
            if (filter.FechaAutorizacion != "^$")
            {
                query = query.Where(asiento => DbContext.DateAsString(asiento.FechaAutorizacion!.Value).Contains(filter.FechaAutorizacion));
            }
            else
            {
                query = query.Where(asiento => asiento.FechaAutorizacion == null);
            }
        }

        if (!string.IsNullOrWhiteSpace(filter.FechaPago))
        {
            if (filter.FechaPago != "^$")
            {
                query = query.Where(asiento => asiento.FechaPago != null && DbContext.DateAsString(asiento.FechaPago.Value).Contains(filter.FechaPago));
            }
            else
            {
                query = query.Where(asiento => asiento.FechaPago == null);
            }
        }

        if (filter.FechaPagoDesde.HasValue || filter.FechaPagoHasta.HasValue)
        {
            query = query.Where(asiento => asiento.FechaPago != null);

            if (filter.FechaPagoDesde.HasValue)
            {
                query = query.Where(asiento => asiento.FechaPago >= filter.FechaPagoDesde.Value);
            }

            if (filter.FechaPagoHasta.HasValue)
            {
                query = query.Where(asiento => asiento.FechaPago <= filter.FechaPagoHasta.Value);
            }
        }

        if (filter.FechaAutorizacionDesde.HasValue)
        {
            query = query.Where(asiento => asiento.FechaAutorizacion != null);

            if (filter.FechaAutorizacionDesde.HasValue)
            {
                query = query.Where(asiento => asiento.FechaAutorizacion >= filter.FechaAutorizacionDesde.Value);
            }

            if (filter.FechaAutorizacionHasta.HasValue)
            {
                query = query.Where(asiento => asiento.FechaAutorizacion <= filter.FechaAutorizacionHasta.Value);
            }
        }

        if (filter.TuteladoId.HasValue)
        {
            query = query.Where(asiento => asiento.TuteladoId == filter.TuteladoId.Value);
        }

        if (filter.ClienteId.HasValue)
        {
            query = query.Where(asiento => asiento.ClienteId == filter.ClienteId.Value);
        }

        return query;
    }

    private IQueryable<Asiento> ApplyFiltersAsientosHuerfanos(IQueryable<Asiento> query, AsientosHuerfanosFilter filter)
    {

        var fecha = new DateTime(2015, 12, 31);

        query = query.Where(asiento => asiento.AccountTransactionCPId == null && asiento.CajaAMTAId == null && asiento.FechaAutorizacion >= fecha && asiento.FechaPago == null);

        if (filter.NoIncluir != null && filter.NoIncluir.Any())
        {
            query = query.Where(asiento => !filter.NoIncluir.Contains((int)asiento.Numero!));
        }

        if (!string.IsNullOrEmpty(filter.Numero))
        {
            query = query.Where(asiento => asiento.Numero != null && DbContext.IntAsString(asiento.Numero.Value).StartsWith(filter.Numero));
        }

        if (!string.IsNullOrWhiteSpace(filter.Partida))
        {
            query = query.Where(asiento => asiento.Partida!.Descripcion.StartsWith(filter.Partida));
        }

        if (!string.IsNullOrWhiteSpace(filter.Capitulo))
        {
            query = query.Where(asiento => asiento.Partida!.Capitulo!.Descripcion.StartsWith(filter.Capitulo));
        }

        if (!string.IsNullOrWhiteSpace(filter.Concepto))
        {
            query = query.Where(asiento => asiento.Concepto != null && asiento.Concepto.Contains(filter.Concepto));
        }

        if (!string.IsNullOrEmpty(filter.Importe))
        {
            query = query.Where(asiento => DbContext.DecimalAsString(asiento.Importe).StartsWith(filter.Importe));
        }

        if (!string.IsNullOrWhiteSpace(filter.FechaAutorizacion))
        {
            query = query.Where(asiento => DbContext.DateAsString(asiento.FechaAutorizacion!.Value).Contains(filter.FechaAutorizacion));
        }


        return query;
    }

    public Task<FondoListItem[]> ObtenerFondoAsync(int page, int total, FondosFilter filter, IEnumerable<CapituloPartidaFilter> partidas)
    {
        var query = from asiento in ApplyFiltersFondos(this.DbSet, partidas)
                    join tutelado in DbContext.Tutelado on asiento.TuteladoId equals tutelado.Id
                    group asiento by new { tutelado.Id, tutelado.NombreCompleto, tutelado.DNI } into g
                    select new FondoListItem()
                    {
                        Id = g.Key.Id,
                        Tutelado = g.Key.NombreCompleto,
                        Dni = g.Key.DNI,
                        Ingresos = g.Where(t => t.Importe > 0).Sum(t => t.Importe),
                        Gastos = g.Where(t => t.Importe < 0).Sum(t => t.Importe),
                        Diferencia = g.Sum(t => t.Importe)
                    };

        query = ApplyFiltersFondos(query, filter);

        return query.OrderBy(a => a.Tutelado)
             .Skip((page - 1) * total)
             .Take(total)
             .AsNoTracking()
             .ToArrayAsync();

    }

    public Task<int> ContarFondoAsync(FondosFilter filter, IEnumerable<CapituloPartidaFilter> partidas)
    {

        var query = from asiento in ApplyFiltersFondos(this.DbSet, partidas)
                    join tutelado in DbContext.Tutelado on asiento.TuteladoId equals tutelado.Id
                    group asiento by new { tutelado.Id, tutelado.NombreCompleto, tutelado.DNI } into g
                    select new FondoListItem()
                    {
                        Id = g.Key.Id,
                        Tutelado = g.Key.NombreCompleto,
                        Dni = g.Key.DNI,
                        Ingresos = g.Where(t => t.Importe > 0).Sum(t => t.Importe),
                        Gastos = g.Where(t => t.Importe < 0).Sum(t => t.Importe),
                        Diferencia = g.Sum(t => t.Importe)
                    };

        query = ApplyFiltersFondos(query, filter);

        return query.CountAsync();
    }

    public Task<decimal> ObtenerDiferenciaFondoAsync(FondosFilter filter, IEnumerable<CapituloPartidaFilter> partidas)
    {
        var query = from asiento in ApplyFiltersFondos(this.DbSet, partidas)
                    join tutelado in DbContext.Tutelado on asiento.TuteladoId equals tutelado.Id
                    group asiento by new { tutelado.Id, tutelado.NombreCompleto, tutelado.DNI } into g
                    select new FondoListItem()
                    {
                        Id = g.Key.Id,
                        Tutelado = g.Key.NombreCompleto,
                        Dni = g.Key.DNI,
                        Ingresos = g.Where(t => t.Importe > 0).Sum(t => t.Importe),
                        Gastos = g.Where(t => t.Importe < 0).Sum(t => t.Importe),
                        Diferencia = g.Sum(t => t.Importe)
                    };

        query = ApplyFiltersFondos(query, filter);

        return query.SumAsync(a => a.Diferencia);
    }


    private IQueryable<Asiento> ApplyFiltersFondos(IQueryable<Asiento> query, IEnumerable<CapituloPartidaFilter> filter)
    {

        var parameter = Expression.Parameter(typeof(Asiento), "a");
        Expression? finalExpression = null;

        foreach (var item in filter)
        {
            var partidaExpression = Expression.Equal(
                Expression.Property(Expression.Property(parameter, "Partida"), "Numero"),
                Expression.Constant(item.Partida)
            );

            var capituloExpression = Expression.Equal(
                Expression.Property(Expression.Property(Expression.Property(parameter, "Partida"), "Capitulo"), "Numero"),
                Expression.Constant(item.Capitulo)
            );

            var andExpression = Expression.AndAlso(partidaExpression, capituloExpression);

            if (finalExpression == null)
            {
                finalExpression = andExpression;
            }
            else
            {
                finalExpression = Expression.OrElse(finalExpression, andExpression);
            }
        }
        if (finalExpression != null)
        {
            var lambda = Expression.Lambda<Func<Asiento, bool>>(finalExpression, parameter);
            query = query.Where(lambda);
        }

        return query;
    }

    private IQueryable<FondoListItem> ApplyFiltersFondos(IQueryable<FondoListItem> query, FondosFilter filter)
    {
        if (filter == null) return query;

        if (!string.IsNullOrWhiteSpace(filter.Tutelado))
        {
            query = query.Where(f => f.Tutelado.Contains(filter.Tutelado));
        }

        if (!string.IsNullOrWhiteSpace(filter.Dni))
        {
            query = query.Where(f => f.Dni.StartsWith(filter.Dni));
        }

        if (!string.IsNullOrEmpty(filter.Ingresos))
        {
            query = query.Where(asiento => DbContext.DecimalAsString(asiento.Ingresos).StartsWith(filter.Ingresos));
        }

        if (!string.IsNullOrEmpty(filter.Gastos))
        {
            query = query.Where(asiento => DbContext.DecimalAsString(asiento.Gastos).StartsWith(filter.Gastos));
        }

        if (!string.IsNullOrEmpty(filter.Diferencia))
        {
            query = query.Where(asiento => DbContext.DecimalAsString(asiento.Gastos).StartsWith(filter.Diferencia));
        }

        return query;
    }

    public Task<IEnumerable<Saldo>> ObtenerSaldosAsync(int page, int total, int ano, SaldosFilter filter)
    {
        var query = ApplyFilters(DbContext.ContabilidadObtenerSaldos(ano), filter);
        return Task.FromResult(query
                .OrderBy(s => s.Tipo).ThenBy(s => s.NumeroCapitulo).ThenBy(s => s.NumeroPartida)
                .Skip((page - 1) * total)
                .Take(total).AsEnumerable());
    }

    public Task<int> ContarSaldosAsync(int ano, SaldosFilter filter)
    {
        return ApplyFilters(DbContext.ContabilidadObtenerSaldos(ano), filter).CountAsync();
    }

    private IQueryable<Saldo> ApplyFilters(IQueryable<Saldo> query, SaldosFilter filter)
    {
        if (filter == null) return query;

        if (!string.IsNullOrWhiteSpace(filter.Descripcion))
        {
            query = query.Where(s => s.Descripcion.Contains(filter.Descripcion));
        }

        if (!string.IsNullOrWhiteSpace(filter.NumeroCapitulo))
        {
            query = query.Where(s => s.NumeroCapitulo.StartsWith(filter.NumeroCapitulo));
        }

        if (!string.IsNullOrWhiteSpace(filter.NumeroPartida))
        {
            query = query.Where(s => s.NumeroPartida != null && s.NumeroPartida.StartsWith(filter.NumeroPartida));
        }

        if (!string.IsNullOrWhiteSpace(filter.Tipo))
        {
            query = query.Where(s => s.Tipo == filter.Tipo);
        }

        if (!string.IsNullOrWhiteSpace(filter.Presupuesto))
        {
            query = query.Where(s => DbContext.DecimalAsString(s.Presupuesto).StartsWith(filter.Presupuesto));
        }

        if (!string.IsNullOrWhiteSpace(filter.Ejecutado))
        {
            query = query.Where(s => s.Ejecutado != null && DbContext.DecimalAsString(s.Ejecutado.Value).StartsWith(filter.Ejecutado));
        }

        if (!string.IsNullOrWhiteSpace(filter.Pendiente))
        {
            query = query.Where(s => s.Pendiente != null && DbContext.DecimalAsString(s.Pendiente.Value).StartsWith(filter.Pendiente));
        }

        if (!string.IsNullOrWhiteSpace(filter.PorcEjecutado))
        {
            query = query.Where(s => s.PorcEjecutado != null && DbContext.DecimalAsString(s.PorcEjecutado.Value).StartsWith(filter.PorcEjecutado));
        }

        return query;
    }


    public Task<Asiento[]> ObtenerAsientosFondoTuteladoAsync(int page, int total, int tuteladoId)
    {
        return ApplyFilters(DbSet, tuteladoId)
            .OrderByDescending(s => s.FechaAutorizacion)
            .Skip((page - 1) * total)
            .Take(total)
            .AsNoTracking()
            .ToArrayAsync();
    }

    public Task<int> ContarAsientosFondoTuteladoAsync(int tuteladoId)
    {
        return ApplyFilters(DbSet, tuteladoId).CountAsync();
    }

    private IQueryable<Asiento> ApplyFilters(IQueryable<Asiento> query, int tuteladoId)
    {
        query = query.Where(a => a.TuteladoId == tuteladoId && ((a.Partida.Numero == "83192" && a.Partida.Capitulo.Numero == "8") || (a.Partida.Numero == "83190" && a.Partida.Capitulo.Numero == "8")));
        return query;
    }

    public Task<IngresosGastos> ObtenerIngresosYGastosFondoTuteladoAsync(int tuteladoId, DateTime? maxFechaAutorizacion = null)
    {
        var fechaLimite = maxFechaAutorizacion.HasValue ? maxFechaAutorizacion.Value.Date : (DateTime?)null;

        var query = @" select isnull(sum(case when Importe > 0 then Importe else 0 end),0) as Ingresos,
                               isnull(sum(case when Importe < 0 then Importe else 0 end),0) as Gastos,
                               isnull(sum(Importe), 0) as Diferencia
                        from Asiento
                        inner join Partida on Pk_Partida = Fk_Partida
                        inner join Capitulo on Pk_Capitulo = Fk_Capitulo
                        where Asiento.Fk_Tutelado=@tuteladoId and ((Partida.Numero='83192' and Capitulo.Numero='8') or (Partida.Numero='83190' and Capitulo.Numero='8'))";

        if (maxFechaAutorizacion.HasValue)
        {
            query += " and FechaAutorizacion is not null and convert(date,FechaAutorizacion) <= @maxFechaAutorizacion";
        }

        return DbContext.Database.GetDbConnection().QueryFirstAsync<IngresosGastos>(query, new { tuteladoId, maxFechaAutorizacion = fechaLimite });
    }
}
