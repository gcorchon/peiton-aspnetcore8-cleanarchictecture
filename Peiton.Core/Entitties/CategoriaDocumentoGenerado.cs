namespace Peiton.Core.Entities
{
    public class CategoriaDocumentoGenerado
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public int? CategoriaDocumentoGeneradoId { get; set; }
		public string? CssClass { get; set; }
		public virtual CategoriaDocumentoGenerado? CategoriaDocumentoGeneradoPadre { get; set; }
		/* public virtual ICollection<CategoriaDocumentoGenerado> CategoriasDocumentosGenerados { get; } = new List<CategoriaDocumentoGenerado>(); */
		/* public virtual ICollection<DocumentoGenerado> DocumentosGenerados { get; } = new List<DocumentoGenerado>(); */
		/* public virtual ICollection<DocumentoGeneradoUrgencia> DocumentosGeneradosUrgencias { get; } = new List<DocumentoGeneradoUrgencia>(); */

	}
}