using Peiton.ListItems;

namespace Peiton.Core.Entities;
[ListItem(ParentValue = "Fk_CategoriaArchivo")]
public class CategoriaArchivo
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public int? CategoriaArchivoId { get; set; }
	public string? CssClass { get; set; }
	public virtual CategoriaArchivo? CategoriaArchivoPadre { get; set; }
	public virtual ICollection<CategoriaArchivo> CategoriasArchivos { get; } = [];
	/* public virtual ICollection<UrgenciaArchivo> UrgenciasArchivos { get; } = new List<UrgenciaArchivo>(); */

}
