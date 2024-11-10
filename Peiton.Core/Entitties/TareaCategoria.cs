using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem(ParentValue = "Fk_TareaDepartamento")]
public class TareaCategoria
{
	public int Id { get; set; }
	public int TareaDepartamentoId { get; set; }
	public string Descripcion { get; set; } = null!;
	public virtual TareaDepartamento TareaDepartamento { get; set; } = null!;
	/* public virtual ICollection<Tarea> Tareas { get; } = new List<Tarea>(); */
	/* public virtual ICollection<TareaSubcategoria> TareasSubcategorias { get; } = new List<TareaSubcategoria>(); */

}
