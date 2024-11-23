namespace Peiton.Contracts.AccountTransactions;

public class AccountTransactionsFilter
{
    public string? Description { get; set; }
    public string? Payee { get; set; }
    public string? Payer { get; set; }
    public string? OperationDate { get; set; }
    public string? ValueDate { get; set; }
    public string? Quantity { get; set; }
    public string? Balance { get; set; }
    public string? Reference { get; set; }
    public string? Categoria { get; set; }
}