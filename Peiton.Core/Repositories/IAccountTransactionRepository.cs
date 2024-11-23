using Peiton.Contracts.AccountTransactions;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IAccountTransactionRepository : IRepository<AccountTransaction>
{
    Task<int> ContarAccountTransactionsAsync(int accountId, AccountTransactionsFilter filter);
    Task<AccountTransaction[]> ObtenerAccountTransactionsAsync(int page, int total, int accountId, AccountTransactionsFilter filter);
    Task<AccountTransaction[]> ObtenerAccountTransactionsAsync(IEnumerable<int> accountTransactionIds);
    Task<AccountTransaction[]> ObtenerAccountTransactionsAsync(int accountId, DateTime desde, DateTime hasta);
}
