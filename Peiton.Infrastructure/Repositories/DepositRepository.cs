using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDepositRepository))]
public class DepositRepository(PeitonDbContext dbContext) : RepositoryBase<Deposit>(dbContext), IDepositRepository
{
	public Task<Deposit[]> ObtenerDepositsAsync(int tuteladoId)
	{
		return DbSet.Include(d => d.Credencial)
		.ThenInclude(c => c.EntidadFinanciera)
		.Where(d => d.Credencial.TuteladoId == tuteladoId).AsNoTracking().ToArrayAsync();
	}
}
