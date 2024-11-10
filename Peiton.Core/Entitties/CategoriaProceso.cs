using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem(ParentValue = "Fk_CategoriaProceso")]
public class CategoriaProceso
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public int? CategoriaProcesoId { get; set; }
	public string? CssClass { get; set; }
	public virtual CategoriaProceso? CategoriaProcesoPadre { get; set; }
	/* public virtual ICollection<CategoriaProceso> CategoriasProcesos { get; } = new List<CategoriaProceso>(); */
	/* public virtual ICollection<Proceso> Procesos { get; } = new List<Proceso>(); */

}
