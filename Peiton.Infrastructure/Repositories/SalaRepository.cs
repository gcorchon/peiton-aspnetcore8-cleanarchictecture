using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Salas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISalaRepository))]
public class SalaRepository(PeitonDbContext dbContext) : RepositoryBase<Sala>(dbContext), ISalaRepository
{
	public Task<int> ContarSalasAsync(SalasFilter filter)
	{
		return ApplyFilter(DbSet, filter).CountAsync();
	}

	public Task<Sala[]> ObtenerSalasAsync(int page, int total, SalasFilter filter)
	{
		return ApplyFilter(DbSet, filter)
				.OrderBy(s => s.Descripcion)
				.Skip((page - 1) * total)
				.Take(total)
				.AsNoTracking()
				.ToArrayAsync();
	}

	private IQueryable<Sala> ApplyFilter(IQueryable<Sala> query, SalasFilter filter)
	{
		if (filter == null) return query;

		if (!string.IsNullOrWhiteSpace(filter.Descripcion))
		{
			query = query.Where(s => s.Descripcion.Contains(filter.Descripcion));
		}

		if (filter.Id.HasValue)
		{
			query = query.Where(s => DbContext.IntAsString(s.Id).StartsWith(filter.Id.Value.ToString()));
		}

		return query;
	}
}
