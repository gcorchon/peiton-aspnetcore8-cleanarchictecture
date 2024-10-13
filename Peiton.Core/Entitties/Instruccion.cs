namespace Peiton.Core.Entities;
public class Instruccion
{
	public int Id { get; set; }
	public int CategoriaInstruccionId { get; set; }
	public string Descripcion { get; set; } = null!;
	public string? ContentType { get; set; }
	public string FileName { get; set; } = null!;
	public DateTime Fecha { get; set; }
	public virtual CategoriaInstruccion CategoriaInstruccion { get; set; } = null!;

}
