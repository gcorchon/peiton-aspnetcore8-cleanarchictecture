using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Caja;
using Peiton.Core.Entities;
using Peiton.Contracts.Enums;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Infrastructure.Utils;

namespace Peiton.Infrastructure.Repositories;
[Injectable(typeof(IVwCajaRepository))]
public class VwCajaRepository : RepositoryBase<VwCaja>, IVwCajaRepository
{
	public VwCajaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<VwCaja[]> ObtenerCajaTuteladoAsync(int page, int total, int tuteladoId, CajaTuteladoFilter filter)
	{
		return ApplyFilters(DbSet, tuteladoId, filter)
			.OrderByDescending(s => s.FechaPago).ThenByDescending(s => s.Id)
			.Skip((page - 1) * total)
			.Take(total)
			.AsNoTracking()
			.ToArrayAsync();
	}

	public Task<int> ContarCajaTuteladoAsync(int tuteladoId, CajaTuteladoFilter filter)
	{
		return ApplyFilters(DbSet, tuteladoId, filter).CountAsync();
	}

	private IQueryable<VwCaja> ApplyFilters(IQueryable<VwCaja> query, int tuteladoId, CajaTuteladoFilter filter)
	{
		query = query.Include(c => c.MetodoPago).Include(c => c.TipoPago).Where(c => c.TuteladoId == tuteladoId);

		if (filter == null) return query;

		if (filter.FechaAutorizacion.HasValue)
		{
			query = query.Where(c => c.FechaAutorizacion.Date == filter.FechaAutorizacion.Value.Date);
		}

		if (filter.FechaPago.HasValue)
		{
			query = query.Where(c => c.FechaPago.HasValue && c.FechaPago.Value.Date == filter.FechaPago.Value.Date);
		}

		if (filter.TipoPagoId.HasValue)
		{
			query = query.Where(c => c.TipoPagoId == filter.TipoPagoId.Value);
		}

		if (filter.MetodoPagoId.HasValue)
		{
			query = query.Where(c => c.MetodoPagoId == filter.MetodoPagoId.Value);
		}

		if (filter.Anticipo.HasValue)
		{
			query = query.Where(c => c.Anticipo == filter.Anticipo.Value);
		}

		if (filter.Importe.HasValue)
		{
			query = query.Where(c => DbContext.DecimalAsString(c.Importe).StartsWith(filter.Importe.Value.ToString()));
		}

		if (filter.Balance.HasValue)
		{
			query = query.Where(c => DbContext.DecimalAsString(c.Balance).StartsWith(filter.Balance.Value.ToString()));
		}

		return query;
	}


}
