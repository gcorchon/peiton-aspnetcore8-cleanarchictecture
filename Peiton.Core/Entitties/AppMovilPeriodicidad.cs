using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class AppMovilPeriodicidad
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<AppMovilCita> AppMovilCitas { get; } = new List<AppMovilCita>(); */
	/* public virtual ICollection<AppMovilTarea> AppMovilTareas { get; } = new List<AppMovilTarea>(); */

}
