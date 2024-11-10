using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TareaEstado
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Tarea> Tareas { get; } = new List<Tarea>(); */

}
