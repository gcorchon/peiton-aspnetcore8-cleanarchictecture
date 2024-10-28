using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Centros;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using SharpCompress;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICentroRepository))]
public class CentroRepository : RepositoryBase<Centro>, ICentroRepository
{
	public CentroRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<int> ContarCentrosAsync(CentrosFilter filter)
	{
		return ApplyFilters(DbSet, filter).CountAsync();
	}

	public Task<Centro[]> ObtenerCentrosAsync(int page, int total, CentrosFilter filter)
	{
		return ApplyFilters(DbSet, filter)
				.OrderBy(c => c.Nombre)
				.Skip((page - 1) * total)
				.Take(total)
				.AsNoTracking()
				.ToArrayAsync();
	}


	private IQueryable<Centro> ApplyFilters(IQueryable<Centro> query, CentrosFilter filter)
	{
		if (filter == null) return query;

		if (!string.IsNullOrEmpty(filter.Nombre))
		{
			query = query.Where(c => c.Nombre.Contains(filter.Nombre));
		}

		if (!string.IsNullOrWhiteSpace(filter.Poblacion))
		{
			query = query.Where(c => c.Poblacion != null && c.Poblacion.Contains(filter.Poblacion));
		}

		if (!string.IsNullOrWhiteSpace(filter.Provincia))
		{
			query = query.Where(c => c.Provincia != null && c.Provincia.Contains(filter.Provincia));
		}

		if (!string.IsNullOrWhiteSpace(filter.CP))
		{
			query = query.Where(c => c.CP != null && c.CP.Contains(filter.CP));
		}

		return query;
	}
}
