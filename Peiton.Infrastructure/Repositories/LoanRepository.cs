using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Dapper;
using Peiton.Contracts.Loans;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ILoanRepository))]
public class LoanRepository(PeitonDbContext dbContext) : RepositoryBase<Loan>(dbContext), ILoanRepository
{
	public Task<Loan[]> ObtenerLoansAsync(int tuteladoId)
	{
		return DbSet.Include(d => d.Credencial).Where(l => l.Credencial.TuteladoId == tuteladoId).ToArrayAsync();
	}

	public Task<IEnumerable<LoanRendicionViewModel>> ObtenerLoansParaRendicionAsync(int tuteladoId, DateTime fechaDesde, DateTime fechaHasta)
	{
		return DbContext.Database.GetDbConnection().QueryAsync<LoanRendicionViewModel>(@"select Id, Numero, EntidadFinanciera, Inicial, Pendiente, Porcentaje, Fecha
						from (
							select Pk_Loan as Id, Loan.AccountNumber as Numero, EntidadFinanciera.Descripcion as EntidadFinanciera,
							Loan.InitialBalance as Inicial, LoanDailyInfo.Debt as Pendiente,Loan.Porcentaje, LoanDailyInfo.Fecha,
							ROW_NUMBER() over (partition by Pk_Loan order by ABS(DATEDIFF(d, @fechaHasta, LoanDailyInfo.Fecha))) as RowNumber
							from Loan inner join LoanDailyInfo on Fk_Loan = Pk_Loan
							inner join Credencial on Fk_Credencial = Pk_Credencial
							inner join EntidadFinanciera on Fk_EntidadFinanciera = Pk_EntidadFinanciera
							where Fk_Tutelado = @TuteladoId 
								and (Loan.BeginDate is not null and Loan.BeginDate < @fechaHasta)
								and (Loan.FechaBaja is null or Loan.FechaBaja > @fechaDesde)
						) dv where RowNumber = 1", new { TuteladoId = tuteladoId, FechaDesde = fechaDesde, FechaHasta = fechaHasta });

	}
}
