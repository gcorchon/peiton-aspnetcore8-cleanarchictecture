using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAccountRepository))]
public class AccountRepository(PeitonDbContext dbContext) : RepositoryBase<Account>(dbContext), IAccountRepository
{
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

	public Task<Account[]> ObtenerAccountsOficinaActivasAsync(int tuteladoId, int entidadFinancieraId, string oficina)
	{
		return DbSet.Include(a => a.Credencial).ThenInclude(c => c.EntidadFinanciera)
			.Where(a => a.Credencial.TuteladoId == tuteladoId
					&& a.Credencial.EntidadFinancieraId == entidadFinancieraId
					&& a.Credencial.DatosCorrectos && !a.Credencial.Baja
					&& a.Credencial.Reintentos < 10 && a.FechaBaja == null
					&& !a.Baja && a.Iban != null && a.Iban.Substring(9, 4) == oficina)
			.AsNoTracking()
			.ToArrayAsync();
	}
}
