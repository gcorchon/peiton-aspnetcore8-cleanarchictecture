using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class MedidaPenalTipo
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<MedidaPenal> MedidasPenales { get; } = new List<MedidaPenal>(); */
	/* public virtual ICollection<MedidaPenalNaturaleza> MedidasPenalesNaturalezas { get; } = new List<MedidaPenalNaturaleza>(); */

}
