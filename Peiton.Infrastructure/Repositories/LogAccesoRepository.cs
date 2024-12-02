using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.LogAccesos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ILogAccesoRepository))]
public class LogAccesoRepository(PeitonDbContext dbContext) : RepositoryBase<LogAcceso>(dbContext), ILogAccesoRepository
{
	public Task<int> ContarLogAccesosAsync(LogAccesosFilter filter)
	{
		return ApplyFilters(DbSet, filter).CountAsync();
	}

	public Task<LogAcceso[]> ObtenerLogAccesosAsync(int page, int total, LogAccesosFilter filter)
	{
		return ApplyFilters(DbSet, filter)
				.OrderByDescending(r => r.Fecha)
				.Skip((page - 1) * total)
				.Take(total)
				.AsNoTracking()
				.ToArrayAsync();
	}

	private IQueryable<LogAcceso> ApplyFilters(IQueryable<LogAcceso> query, LogAccesosFilter filter)
	{
		if (filter == null) return query;

		if (!string.IsNullOrWhiteSpace(filter.Usuario))
		{
			query = query.Where(r => r.Usuario.Contains(filter.Usuario));
		}

		if (!string.IsNullOrWhiteSpace(filter.IP))
		{
			query = query.Where(r => r.IP.StartsWith(filter.IP));
		}

		if (filter.Fecha != null)
		{
			query = query.Where(r => r.Fecha.Date == filter.Fecha.Value.Date);
		}

		return query;
	}
}
