using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.EntidadFinanciera;
using Peiton.Contracts.Account;

namespace Peiton.Infrastructure.Repositories;
[Injectable(typeof(IEntidadFinancieraRepository))]
public class EntidadFinancieraRepository(PeitonDbContext dbContext) : RepositoryBase<EntidadFinanciera>(dbContext), IEntidadFinancieraRepository
{
	public Task<EntidadFinancieraViewModel[]> ObtenerEntidadesConCuentasActivasAsync(int tuteladoId)
	{
		var query = from account in DbContext.Account
					where account.Credencial.TuteladoId == tuteladoId && !account.Baja && !account.Credencial.Baja
					group account by new { account.Credencial.EntidadFinanciera.Id, account.Credencial.EntidadFinanciera.Descripcion, account.Credencial.EntidadFinanciera.CssClass } into g
					select new EntidadFinancieraViewModel()
					{
						Id = g.Key.Id,
						Descripcion = g.Key.Descripcion,
						CssClass = g.Key.CssClass,
						Accounts = g.Select(a => new AccountViewModel()
						{
							Id = a.Id,
							WebAlias = a.WebAlias,
							Iban = a.Iban,
							Saldo = a.Saldo,
							Fecha = a.Fecha,
							FechaSaldo = a.FechaSaldo
						})
					};

		return query.OrderBy(e => e.Descripcion).AsNoTracking().ToArrayAsync();
	}
}
