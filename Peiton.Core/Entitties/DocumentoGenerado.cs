namespace Peiton.Core.Entities;
public class DocumentoGenerado
{
	public int Id { get; set; }
	public int CategoriaDocumentoGeneradoId { get; set; }
	public string Descripcion { get; set; } = null!;
	public string ContentType { get; set; } = null!;
	public string FileName { get; set; } = null!;
	public DateTime Fecha { get; set; }
	public string? Tags { get; set; }
	public virtual CategoriaDocumentoGenerado CategoriaDocumentoGenerado { get; set; } = null!;

}
