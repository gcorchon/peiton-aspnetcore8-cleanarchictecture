using Peiton.Contracts.AccountTransactions;

namespace Peiton.Contracts.Account;

public class AccountWithTransactions
{
    public string Descripcion { get; set; } = null!;
    public IEnumerable<AccountTransactionListItem> Transactions { get; set; } = [];
}