namespace Peiton.Core.Entities
{
    public class UrgenciaCoste
	{
		public int UrgenciaId { get; set; }
		public int Orden { get; set; }
		public int UrgenciaConceptoCosteId { get; set; }
		public decimal Valoracion { get; set; }
		public virtual Urgencia Urgencia { get; set; }= null!;
		public virtual UrgenciaConceptoCoste UrgenciaConceptoCoste { get; set; }= null!;

	}
}