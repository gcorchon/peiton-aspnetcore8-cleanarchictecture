using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ILoanRepository))]
public class LoanRepository(PeitonDbContext dbContext) : RepositoryBase<Loan>(dbContext), ILoanRepository
{
	public Task<Loan[]> ObtenerLoansAsync(int tuteladoId)
	{
		return DbSet.Include(d => d.Credencial).Where(l => l.Credencial.TuteladoId == tuteladoId).ToArrayAsync();
	}
}
