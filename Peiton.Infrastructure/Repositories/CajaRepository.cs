using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Caja;
using Peiton.Core.Entities;
using Peiton.Core.Enums;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{
	[Injectable(typeof(ICajaRepository))]
	public class CajaRepository : RepositoryBase<Caja>, ICajaRepository
	{
		public CajaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}

		public Task<int> ContarMovimientosAsync(TipoMovimiento tipo, CajaFilter filter)
		{
			return ApplyFilters(DbSet.Include(c => c.Tutelado).Include(c => c.TipoPago), tipo, filter).CountAsync();
		}

		public Task<List<Caja>> ObtenerMovimientosAsync(int page, int total, TipoMovimiento tipo, CajaFilter filter)
		{
			return ApplyFilters(DbSet.Include(c => c.Tutelado).Include(c => c.TipoPago), tipo, filter)
				.OrderByDescending(c => c.FechaAutorizacion)
				.Skip((page - 1) * total)
				.Take(total)
				.AsNoTracking()
				.ToListAsync();
		}

		private IQueryable<Caja> ApplyFilters(IQueryable<Caja> query, TipoMovimiento tipo, CajaFilter filter)
		{

			query = query.Where(c => c.MetodoPagoId == (int)tipo);

			if (!string.IsNullOrWhiteSpace(filter.Concepto))
			{
				query = query.Where(c => c.Concepto.Contains(filter.Concepto));
			}

			if (!string.IsNullOrWhiteSpace(filter.FechaAutorizacion))
			{
				query = query.Where(c => DbContext.DateAsString(c.FechaAutorizacion).Contains(filter.FechaAutorizacion));
			}

			if (!string.IsNullOrWhiteSpace(filter.FechaPago))
			{
				query = query.Where(c => c.FechaPago != null && DbContext.DateAsString(c.FechaPago.Value).Contains(filter.FechaPago));
			}

			if (!string.IsNullOrWhiteSpace(filter.Nombre))
			{
				query = query.Where(c => c.Tutelado.NombreCompleto!.Contains(filter.Nombre));
			}

			if (filter.Tipo.HasValue)
			{
				query = query.Where(c => c.TipoPagoId == filter.Tipo.Value);
			}

			if (!string.IsNullOrWhiteSpace(filter.Importe))
			{
				query = query.Where(c => DbContext.DecimalAsString(c.Importe).StartsWith(filter.Importe));
			}

			if (filter.Pendiente.HasValue)
			{
				query = query.Where(c => c.Pendiente == filter.Pendiente.Value);
			}

			return query;
		}

		public async Task<decimal> ObtenerSaldoCajaAsync(int tuteladoId)
		{
			var saldoInicialCaja = await DbContext.Tutelado.Where(t => t.Id == tuteladoId).Select(t => t.SaldoInicialCaja).SingleAsync();
			var total = await DbSet.Where(c => !c.Anticipo && !c.Pendiente && c.TuteladoId == tuteladoId).SumAsync(c => c.Importe);
			return total + saldoInicialCaja;
		}
	}
}