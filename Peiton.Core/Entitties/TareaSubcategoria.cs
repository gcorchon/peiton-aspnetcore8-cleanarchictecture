namespace Peiton.Core.Entities;
public class TareaSubcategoria
{
	public int Id { get; set; }
	public int TareaCategoriaId { get; set; }
	public string Descripcion { get; set; } = null!;
	public virtual TareaCategoria TareaCategoria { get; set; } = null!;
	/* public virtual ICollection<Tarea> Tareas { get; } = new List<Tarea>(); */

}
