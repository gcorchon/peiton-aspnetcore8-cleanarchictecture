using Peiton.Contracts.Account;
using Peiton.Contracts.Common;

namespace Peiton.Contracts.AccountTransactions;

public class ExtractoWordViewModel
{
    public string Tutelado { get; set; } = null!;
    public string Intervalo { get; set; } = null!;
    public List<AccountWithTransactions> Accounts { get; set; } = [];
}