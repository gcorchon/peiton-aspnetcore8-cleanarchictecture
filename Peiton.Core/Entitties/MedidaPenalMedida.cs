namespace Peiton.Core.Entities
{
    public class MedidaPenalMedida
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public int MedidaPenalNaturalezaId { get; set; }
		public virtual MedidaPenalNaturaleza MedidaPenalNaturaleza { get; set; }= null!;
		/* public virtual ICollection<MedidaPenal> MedidasPenales { get; } = new List<MedidaPenal>(); */

	}
}