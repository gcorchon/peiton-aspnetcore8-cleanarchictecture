using Microsoft.EntityFrameworkCore;
using Peiton.Core.Repositories;
using Peiton.Contracts.Asientos;
using Peiton.Core.Entities;
using Peiton.DependencyInjection;
using Peiton.Contracts.Common;
using System.Security.Cryptography;
using System.Linq.Expressions;

namespace Peiton.Infrastructure.Repositories
{
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

        public Task<List<Asiento>> ObtenerAsientosAsync(int page, int total, AsientosFilter filter)
        {
            var query = ApplyFilters(this.DbSet.Include(a => a.Partida).ThenInclude(b => b!.Capitulo), filter);
            return query.OrderByDescending(asiento => asiento.Id)
                 .Skip((page - 1) * total)
                 .Take(total)
                 .AsNoTracking()
                 .ToListAsync();
        }

        public Task<int> ContarAsientosHuerfanosAsync(AsientosHuerfanosFilter filter)
        {
            var query = ApplyFiltersAsientosHuerfanos(this.DbSet.Include(a => a.Partida).ThenInclude(b => b!.Capitulo), filter);
            return query.CountAsync();
        }

        public Task<List<Asiento>> ObtenerAsientosHuerfanosAsync(int page, int total, AsientosHuerfanosFilter filter)
        {
            var query = ApplyFiltersAsientosHuerfanos(this.DbSet.Include(a => a.Partida).ThenInclude(b => b!.Capitulo), filter);
            return query.OrderByDescending(asiento => asiento.Id)
                 .Skip((page - 1) * total)
                 .Take(total)
                 .AsNoTracking()
                 .ToListAsync();
        }

        public Task<int> ObtenerUltimoNumeroAsientoAsync(int ano)
        {
            return this.DbContext.Database.SqlQuery<int>($"select coalesce(max(Numero), 0) as Value from Asiento where YEAR(FechaAutorizacion) = {ano}").FirstAsync();
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
                query = query.Where(asiento => asiento.Numero != null && this.DbContext.IntAsString(asiento.Numero.Value).StartsWith(filter.Numero));
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
                query = query.Where(asiento => this.DbContext.DecimalAsString(asiento.Importe).StartsWith(filter.Importe));
            }

            if (!string.IsNullOrWhiteSpace(filter.FechaAutorizacion))
            {
                if (filter.FechaAutorizacion != "^$")
                {
                    query = query.Where(asiento => this.DbContext.DateAsString(asiento.FechaAutorizacion!.Value).Contains(filter.FechaAutorizacion));
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
                    query = query.Where(asiento => asiento.FechaPago != null && this.DbContext.DateAsString(asiento.FechaPago.Value).Contains(filter.FechaPago));
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
                query = query.Where(asiento => asiento.Numero != null && this.DbContext.IntAsString(asiento.Numero.Value).StartsWith(filter.Numero));
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
                query = query.Where(asiento => this.DbContext.DecimalAsString(asiento.Importe).StartsWith(filter.Importe));
            }

            if (!string.IsNullOrWhiteSpace(filter.FechaAutorizacion))
            {
                query = query.Where(asiento => this.DbContext.DateAsString(asiento.FechaAutorizacion!.Value).Contains(filter.FechaAutorizacion));
            }


            return query;
        }

        public Task<List<FondoListItem>> ObtenerFondoAsync(int page, int total, FondosFilter filter, IEnumerable<CapituloPartidaFilter> partidas)
        {


            var query = from asiento in ApplyFiltersFondos(this.DbSet, partidas)
                        join tutelado in this.DbContext.Tutelado on asiento.TuteladoId equals tutelado.Id
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
                 .ToListAsync();

        }

        public Task<int> ContarFondoAsync(FondosFilter filter, IEnumerable<CapituloPartidaFilter> partidas)
        {

            var query = from asiento in ApplyFiltersFondos(this.DbSet, partidas)
                        join tutelado in this.DbContext.Tutelado on asiento.TuteladoId equals tutelado.Id
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
            throw new NotImplementedException();
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
                query = query.Where(asiento => this.DbContext.DecimalAsString(asiento.Ingresos).StartsWith(filter.Ingresos));
            }

            if (!string.IsNullOrEmpty(filter.Gastos))
            {
                query = query.Where(asiento => this.DbContext.DecimalAsString(asiento.Gastos).StartsWith(filter.Gastos));
            }

            if (!string.IsNullOrEmpty(filter.Diferencia))
            {
                query = query.Where(asiento => this.DbContext.DecimalAsString(asiento.Gastos).StartsWith(filter.Diferencia));
            }

            return query;
        }
    }
}