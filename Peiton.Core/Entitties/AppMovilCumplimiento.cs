using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class AppMovilCumplimiento
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<AppMovilTarea> AppMovilTareas { get; } = new List<AppMovilTarea>(); */

}
