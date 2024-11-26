using Dapper;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDepositDailyBalanceRepository))]
public class DepositDailyBalanceRepository : RepositoryBase<DepositDailyBalance>, IDepositDailyBalanceRepository
{
	public DepositDailyBalanceRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public async Task<DailyBalance?> ObtenerBalanceAsync(int id, DateTime fechaCertificado)
	{
		return await DbContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<DailyBalance>("select * from  dbo.ObtenerSaldoDeposit(@DepositId, @Fecha) where Saldo is not null", new { DepositId = id, Fecha = fechaCertificado });
	}
}
