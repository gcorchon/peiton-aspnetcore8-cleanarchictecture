using Dapper;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Account;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAccountDailyBalanceRealRepository))]
public class AccountDailyBalanceRealRepository : RepositoryBase<AccountDailyBalanceReal>, IAccountDailyBalanceRealRepository
{
	public AccountDailyBalanceRealRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<DailyBalance?> ObtenerBalanceAsync(int accountId, DateTime fecha)
	{
		return DbContext.Database.GetDbConnection()
				.QueryFirstOrDefaultAsync<DailyBalance>("select top 1 Balance as Saldo, Fecha as FechaSaldo from AccountDailyBalanceReal where Fk_Account=@AccountId order by ABS(DATEDIFF(day, Fecha, @FechaSolicitada))",
					new { FechaSolicitada = fecha, AccountId = accountId });


	}
}
