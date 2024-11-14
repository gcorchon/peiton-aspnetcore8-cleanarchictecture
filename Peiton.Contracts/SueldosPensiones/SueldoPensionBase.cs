namespace Peiton.Contracts.SueldosPensiones;

public class SueldoPensionBase
{
    public decimal Importe { get; set; }
    public int NumeroPagas { get; set; }
    public string? Observaciones { get; set; }
    public int Ano { get; set; }
}