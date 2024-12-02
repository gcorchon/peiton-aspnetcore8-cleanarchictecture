using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IShareRepository))]
public class ShareRepository(PeitonDbContext dbContext) : RepositoryBase<Share>(dbContext), IShareRepository
{
	public Task<Share[]> ObtenerSharesAsync(int tuteladoId)
	{
		return DbSet.Include(s => s.Credencial)
		.ThenInclude(c => c.EntidadFinanciera)
		.Where(s => s.Credencial.TuteladoId == tuteladoId).AsNoTracking().ToArrayAsync();
	}
}
