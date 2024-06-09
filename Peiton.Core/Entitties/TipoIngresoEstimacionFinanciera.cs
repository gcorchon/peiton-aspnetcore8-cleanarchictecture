namespace Peiton.Core.Entities
{
    public class TipoIngresoEstimacionFinanciera
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public int ConceptoIngresoEstimacionFinancieraId { get; set; }
		public virtual ConceptoIngresoEstimacionFinanciera ConceptoIngresoEstimacionFinanciera { get; set; }= null!;
		/* public virtual ICollection<IngresoEstimacionFinanciera> IngresosEstimacionesFinancieras { get; } = new List<IngresoEstimacionFinanciera>(); */

	}
}