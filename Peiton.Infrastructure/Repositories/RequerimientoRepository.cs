using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Requerimientos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRequerimientoRepository))]
public class RequerimientoRepository : RepositoryBase<Requerimiento>, IRequerimientoRepository
{
	public RequerimientoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<int> ContarRequerimientosAsync(RequerimientosFilter filter)
	{
		return ApplyFilters(DbSet.Include(r => r.Tutelado).Include(r => r.RequerimientoTipo).Include(r => r.RequerimientoDetalle), filter).CountAsync();
	}

	public Task<Requerimiento[]> ObtenerRequerimientosAsync(int page, int total, RequerimientosFilter filter)
	{
		return ApplyFilters(DbSet.Include(r => r.Tutelado).Include(r => r.RequerimientoTipo).Include(r => r.RequerimientoDetalle), filter)
			.OrderByDescending(s => s.Id)
			.Skip((page - 1) * total)
			.Take(total)
			.AsNoTracking()
			.ToArrayAsync();
	}

	private IQueryable<Requerimiento> ApplyFilters(IQueryable<Requerimiento> query, RequerimientosFilter filter)
	{
		if (filter == null) return query;

		if (filter.Id.HasValue)
		{
			query = query.Where(t => t.Id.ToString().StartsWith(filter.Id.Value.ToString()));
		}

		if (!string.IsNullOrWhiteSpace(filter.Tutelado))
		{
			query = query.Where(t => t.Tutelado.NombreCompleto!.Contains(filter.Tutelado));
		}

		if (filter.Contestado.HasValue)
		{
			query = query.Where(t => t.Contestado == filter.Contestado.Value);
		}

		if (filter.DetalleId.HasValue)
		{
			query = query.Where(t => t.RequerimientoDetalleId == filter.DetalleId);
		}

		if (filter.TipoId.HasValue)
		{
			query = query.Where(t => t.RequerimientoTipoId == filter.TipoId);
		}

		return query;
	}
}
