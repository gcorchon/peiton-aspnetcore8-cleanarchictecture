using Dapper;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IShareDailyBalanceRepository))]
public class ShareDailyBalanceRepository(PeitonDbContext dbContext) : RepositoryBase<ShareDailyBalance>(dbContext), IShareDailyBalanceRepository
{
	public async Task<DailyBalance?> ObtenerBalanceAsync(int id, DateTime fechaCertificado)
	{
		return await DbContext.Database.GetDbConnection()
				.QueryFirstOrDefaultAsync<DailyBalance>("select * from dbo.ObtenerSaldoShare(@ShareId, @Fecha) where Saldo is not null", new { ShareId = id, Fecha = fechaCertificado });
	}
}
