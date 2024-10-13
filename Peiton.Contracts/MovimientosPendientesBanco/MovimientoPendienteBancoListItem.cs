namespace Peiton.Contracts.MovimientosPendientesBanco;
public class MovimientoPendienteBancoListItem
{
    public int Id { get; set; } //AccountTransactionCP Id
    public int AccountCPId { get; set; }
    public string AccountCPName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Reference { get; set; } = null!;
    public string Payer { get; set; } = null!;
    public string Payee { get; set; } = null!;
    public DateTime OperationDate { get; set; }
    public DateTime ValueDate { get; set; }
    public decimal Quantity { get; set; }
}
