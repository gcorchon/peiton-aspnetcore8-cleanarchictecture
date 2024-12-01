namespace Peiton.Core.Entities;
public class Documento
{
	public int Id { get; set; }
	public int CategoriaDocumentoId { get; set; }
	public string Descripcion { get; set; } = null!;
	public string ContentType { get; set; } = null!;
	public string FileName { get; set; } = null!;
	public DateTime Fecha { get; set; }
	public string? Tags { get; set; }
	public virtual CategoriaDocumento CategoriaDocumento { get; set; } = null!;

}
