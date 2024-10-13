using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Peiton.Contracts.Caja;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICajaIncidenciaRepository))]
public class CajaIncidenciaRepository : RepositoryBase<CajaIncidencia>, ICajaIncidenciaRepository
{
	public CajaIncidenciaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<int> ContarIncidenciasAsync(IncidenciasFilter filter)
	{
		return ApplyFilters(DbSet.Include(i => i.Tutelado), filter).CountAsync();
	}

	public Task<List<CajaIncidencia>> ObtenerIncidenciasAsync(int page, int total, IncidenciasFilter filter)
	{
		return ApplyFilters(DbSet.Include(i => i.Tutelado).Include(i => i.RazonIncidenciaCaja), filter)
					.OrderByDescending(i => i.FechaIncidencia)
					.Skip((page - 1) * total)
					.Take(total)
					.AsNoTracking()
					.ToListAsync();
	}

	IQueryable<CajaIncidencia> ApplyFilters(IQueryable<CajaIncidencia> query, IncidenciasFilter filter)
	{
		if (filter == null) return query;

		if (!string.IsNullOrWhiteSpace(filter.Concepto))
		{
			query = query.Where(i => i.Concepto.Contains(filter.Concepto));
		}

		if (!string.IsNullOrWhiteSpace(filter.FechaPago))
		{
			query = query.Where(i => i.FechaPago != null && DbContext.DateAsString(i.FechaPago.Value).Contains(filter.FechaPago));
		}

		if (!string.IsNullOrWhiteSpace(filter.Importe))
		{
			query = query.Where(i => DbContext.DecimalAsString(i.Importe).StartsWith(filter.Importe));
		}

		if (!string.IsNullOrWhiteSpace(filter.Nombre))
		{
			query = query.Where(i => i.Tutelado.NombreCompleto!.Contains(filter.Nombre));
		}

		if (filter.RazonIncidencia.HasValue)
		{
			query = query.Where(i => i.RazonIncidenciaCajaId == filter.RazonIncidencia.Value);
		}

		return query;
	}
}
