using Peiton.Contracts.Loans;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ILoanRepository : IRepository<Loan>
{
    Task<Loan[]> ObtenerLoansAsync(int tuteladoId);
    Task<IEnumerable<LoanRendicionViewModel>> ObtenerLoansParaRendicionAsync(int tuteladoId, DateTime fechaDesde, DateTime fechaHasta);
}
