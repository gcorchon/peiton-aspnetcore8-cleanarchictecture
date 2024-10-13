namespace Peiton.Core.Entities;
public class MedidaPenalNaturaleza
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public int MedidaPenalTipoId { get; set; }
	public virtual MedidaPenalTipo MedidaPenalTipo { get; set; } = null!;
	/* public virtual ICollection<MedidaPenal> MedidasPenales { get; } = new List<MedidaPenal>(); */
	/* public virtual ICollection<MedidaPenalMedida> MedidasPenalesMedidas { get; } = new List<MedidaPenalMedida>(); */

}
