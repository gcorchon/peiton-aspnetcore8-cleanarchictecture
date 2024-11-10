using Peiton.Contracts.Common;
using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem(ParentValue = "Fk_MedidaPenalNaturaleza")]
public class MedidaPenalMedida
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public int MedidaPenalNaturalezaId { get; set; }
	public virtual MedidaPenalNaturaleza MedidaPenalNaturaleza { get; set; } = null!;
	/* public virtual ICollection<MedidaPenal> MedidasPenales { get; } = new List<MedidaPenal>(); */

}
