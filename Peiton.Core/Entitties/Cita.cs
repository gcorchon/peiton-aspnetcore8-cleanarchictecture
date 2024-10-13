namespace Peiton.Core.Entities;
public class Cita
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public string Descripcion { get; set; } = null!;
	public DateTime Fecha { get; set; }
	public int UsuarioId { get; set; }
	public DateTime FechaCreacion { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;
	public virtual Usuario Usuario { get; set; } = null!;

}
