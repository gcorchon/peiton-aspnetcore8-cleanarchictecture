using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ILoanRepository : IRepository<Loan>
{
    Task<Loan[]> ObtenerLoansAsync(int tuteladoId);
}
