namespace Peiton.Core.Entities;
public class UrgenciaArchivo
{
	public int Id { get; set; }
	public int UrgenciaId { get; set; }
	public int CategoriaArchivoId { get; set; }
	public string Descripcion { get; set; } = null!;
	public string? ContentType { get; set; }
	public string FileName { get; set; } = null!;
	public DateTime Fecha { get; set; }
	public string? Tags { get; set; }
	public virtual CategoriaArchivo CategoriaArchivo { get; set; } = null!;
	public virtual Urgencia Urgencia { get; set; } = null!;

}
