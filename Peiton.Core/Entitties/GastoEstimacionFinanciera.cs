namespace Peiton.Core.Entities
{
    public class GastoEstimacionFinanciera
	{
		public int TuteladoId { get; set; }
		public int Orden { get; set; }
		public int? ConceptoGastoEstimacionFinancieraId { get; set; }
		public int? FormaPagoGastoEstimacionFinancieraId { get; set; }
		public decimal? Importe { get; set; }
		public string? Frecuencia { get; set; }
		public virtual ConceptoGastoEstimacionFinanciera? ConceptoGastoEstimacionFinanciera { get; set; }
		public virtual FormaPagoGastoEstimacionFinanciera? FormaPagoGastoEstimacionFinanciera { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}