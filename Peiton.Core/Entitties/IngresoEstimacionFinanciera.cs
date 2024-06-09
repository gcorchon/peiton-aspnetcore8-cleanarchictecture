namespace Peiton.Core.Entities
{
    public class IngresoEstimacionFinanciera
	{
		public int TuteladoId { get; set; }
		public int Orden { get; set; }
		public int? ConceptoIngresoEstimacionFinancieraId { get; set; }
		public int? TipoIngresoEstimacionFinancieraId { get; set; }
		public int? OrganismoIngresoEstimacionFinancieraId { get; set; }
		public decimal? Importe { get; set; }
		public virtual ConceptoIngresoEstimacionFinanciera? ConceptoIngresoEstimacionFinanciera { get; set; }
		public virtual OrganismoIngresoEstimacionFinanciera? OrganismoIngresoEstimacionFinanciera { get; set; }
		public virtual TipoIngresoEstimacionFinanciera? TipoIngresoEstimacionFinanciera { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}