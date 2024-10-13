namespace Peiton.Contracts.Inmuebles;

public class CuentaDocumentoPago
{
    public int Pk_Account { get; set; }
    public string NumeroCompleto { get; set; } = null!;
    public decimal? Saldo { get; set; }
    public DateTime? FechaSaldo { get; set; }
}
