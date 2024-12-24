using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInformePersonalRepository))]
public class InformePersonalRepository(PeitonDbContext dbContext) : RepositoryBase<InformePersonal>(dbContext), IInformePersonalRepository
{
	public Task<int> ContarInformesPersonalesAsync(int tuteladoId)
	{
		return ApplyFilters(DbSet, tuteladoId).CountAsync();
	}

	public Task<InformePersonal[]> ObtenerInformesPersonalesAsync(int page, int total, int tuteladoId)
	{
		return ApplyFilters(DbSet, tuteladoId)
			.OrderByDescending(s => s.Id)
			.Skip((page - 1) * total)
			.Take(total)
			.AsNoTracking()
			.ToArrayAsync();
	}

	private IQueryable<InformePersonal> ApplyFilters(IQueryable<InformePersonal> query, int tuteladoId)
	{
		query = query.Include(i => i.Usuario).Where(i => i.TuteladoId == tuteladoId);
		return query;
	}

	public Task<InformePersonal?> ObtenerUltimoInformePersonalAsync(int tuteladoId)
	{
		return DbSet.OrderByDescending(i => i.Fecha).FirstOrDefaultAsync();
	}
}
