namespace Peiton.Core.Entities;
public class CategoriaArchivo
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public int? CategoriaArchivoId { get; set; }
	public string? CssClass { get; set; }
	public virtual CategoriaArchivo? CategoriaArchivoPadre { get; set; }
	/* public virtual ICollection<CategoriaArchivo> CategoriasArchivos { get; } = new List<CategoriaArchivo>(); */
	/* public virtual ICollection<UrgenciaArchivo> UrgenciasArchivos { get; } = new List<UrgenciaArchivo>(); */

}
