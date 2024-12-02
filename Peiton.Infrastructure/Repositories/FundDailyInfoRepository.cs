using Dapper;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFundDailyInfoRepository))]
public class FundDailyInfoRepository(PeitonDbContext dbContext) : RepositoryBase<FundDailyInfo>(dbContext), IFundDailyInfoRepository
{
	public async Task<DailyBalance?> ObtenerBalanceAsync(int id, DateTime fechaCertificado)
	{
		return await DbContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<DailyBalance>("select * from  dbo.ObtenerSaldoFund(@FundId, @Fecha) where Saldo is not null", new { FundId = id, Fecha = fechaCertificado });
	}
}
