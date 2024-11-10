using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class MedidaPIA
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<InformePersonalPIA> InformesPersonalesPIA { get; } = new List<InformePersonalPIA>(); */

}
