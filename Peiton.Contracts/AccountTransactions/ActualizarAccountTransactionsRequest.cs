namespace Peiton.Contracts.AccountTransactions;

public class ActualizarAccountTransactionsRequest
{
    public int CategoriaId { get; set; }
    public IEnumerable<int> AccountTransactionIds { get; set; } = null!;
}