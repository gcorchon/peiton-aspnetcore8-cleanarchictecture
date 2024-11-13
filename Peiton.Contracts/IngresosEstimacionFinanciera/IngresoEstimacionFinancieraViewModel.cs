namespace Peiton.Contracts.IngresosEstimacionFinanciera;

public class IngresoEstimacionFinancieraViewModel
{
    public int Orden { get; set; }
    public int? ConceptoIngresoEstimacionFinancieraId { get; set; }
    public int? TipoIngresoEstimacionFinancieraId { get; set; }
    public int? OrganismoIngresoEstimacionFinancieraId { get; set; }
    public decimal? Importe { get; set; }
}