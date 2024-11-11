using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Directorio;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDirectorioAMTARepository))]
public class DirectorioAMTARepository : RepositoryBase<DirectorioAMTA>, IDirectorioAMTARepository
{
	public DirectorioAMTARepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<DirectorioAMTA[]> ObtenerDirectorioAsync(DirectorioFilter filter)
	{
		return ApplyFilters(DbSet, filter)
				.OrderBy(d => d.NombreCompleto)
				.Take(20)
				.AsNoTracking()
				.ToArrayAsync();
	}


	private IQueryable<DirectorioAMTA> ApplyFilters(IQueryable<DirectorioAMTA> query, DirectorioFilter filter)
	{
		query = query.Where(d => d.Mostrar);

		if (!string.IsNullOrWhiteSpace(filter.NombreCompleto))
		{
			query = query.Where(s => s.NombreCompleto.Contains(filter.NombreCompleto));
		}

		if (!string.IsNullOrWhiteSpace(filter.Cargo))
		{
			query = query.Where(s => s.Cargo != null && s.Cargo.Contains(filter.Cargo));
		}

		if (!string.IsNullOrWhiteSpace(filter.Grupos))
		{
			query = query.Where(s => s.Grupos != null && s.Grupos.Contains(filter.Grupos));
		}

		return query;
	}
}
