namespace Peiton.Contracts.GastosEstimacionFinanciera;

public class GastoEstimacionFinancieraViewModel
{
    public int Orden { get; set; }
    public int? ConceptoGastoEstimacionFinancieraId { get; set; }
    public int? FormaPagoGastoEstimacionFinancieraId { get; set; }
    public decimal? Importe { get; set; }
    public string? Frecuencia { get; set; }
}