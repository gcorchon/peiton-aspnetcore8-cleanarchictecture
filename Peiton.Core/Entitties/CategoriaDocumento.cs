using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem(ParentValue = "Fk_CategoriaDocumento")]
public class CategoriaDocumento
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public int? CategoriaDocumentoId { get; set; }
	public string? CssClass { get; set; }
	public virtual CategoriaDocumento? CategoriaDocumentoPadre { get; set; }
	public virtual ICollection<CategoriaDocumento> CategoriasDocumentos { get; } = new List<CategoriaDocumento>();
	/* public virtual ICollection<Documento> Documentos { get; } = new List<Documento>(); */

}
