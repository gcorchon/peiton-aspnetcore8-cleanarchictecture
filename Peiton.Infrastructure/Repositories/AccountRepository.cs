using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAccountRepository))]
public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
	public AccountRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<Account[]> ObtenerAccountsAsync(int tuteladoId)
	{
		return DbSet.Include(a => a.Credencial).ThenInclude(c => c.EntidadFinanciera)
			.Where(a => a.Credencial.TuteladoId == tuteladoId)
			.AsNoTracking()
			.ToArrayAsync();
	}

	public Task<Account[]> ObtenerCuentasConMovimientosAsync(int tuteladoId, DateTime desde, DateTime hasta)
	{
		return DbSet.Include(a => a.Credencial).ThenInclude(c => c.EntidadFinanciera)
			.Where(a => a.Credencial.TuteladoId == tuteladoId && a.AccountsTransactions.Any(act => act.OperationDate >= desde && act.OperationDate <= hasta))
			.AsNoTracking()
			.ToArrayAsync();
	}
}
