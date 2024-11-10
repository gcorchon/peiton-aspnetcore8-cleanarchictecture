using Peiton.ListItems;

namespace Peiton.Core.Entities;
[ListItem]
public class TareaDepartamento
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Tarea> Tareas { get; } = new List<Tarea>(); */
	/* public virtual ICollection<TareaCategoria> TareasCategorias { get; } = new List<TareaCategoria>(); */

}
