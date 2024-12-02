using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFundRepository))]
public class FundRepository(PeitonDbContext dbContext) : RepositoryBase<Fund>(dbContext), IFundRepository
{
	public Task<Fund[]> ObtenerFundsAsync(int tuteladoId)
	{
		return DbSet.Include(f => f.Credencial)
		.ThenInclude(c => c.EntidadFinanciera)
		.Where(f => f.Credencial.TuteladoId == tuteladoId).AsNoTracking().ToArrayAsync();
	}
}
