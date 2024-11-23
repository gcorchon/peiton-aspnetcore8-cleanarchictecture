using Peiton.Contracts.Common;

namespace Peiton.Contracts.AccountTransactions;

public class AccountTransactionListItem
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? Payee { get; set; }
    public string? Payer { get; set; }
    public DateTime OperationDate { get; set; }
    public DateTime ValueDate { get; set; }
    public decimal Quantity { get; set; }

    public decimal? Balance { get; set; }
    public string? Reference { get; set; }
    public ListItem? Categoria { get; set; }

}