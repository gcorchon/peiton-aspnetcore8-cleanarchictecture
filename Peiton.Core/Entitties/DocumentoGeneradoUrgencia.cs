namespace Peiton.Core.Entities;
public class DocumentoGeneradoUrgencia
{
	public int Id { get; set; }
	public int CategoriaDocumentoGeneradoId { get; set; }
	public string Descripcion { get; set; } = null!;
	public string? ContentType { get; set; }
	public string FileName { get; set; } = null!;
	public DateTime Fecha { get; set; }
	public string? Tags { get; set; }
	public virtual CategoriaDocumentoGenerado CategoriaDocumentoGenerado { get; set; } = null!;

}
