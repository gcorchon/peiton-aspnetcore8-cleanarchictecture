namespace Peiton.Core.Entities;
public class SalaReserva
{
	public int SalaId { get; set; }
	public DateTime Fecha { get; set; }
	public string Intervalo { get; set; } = null!;
	public int UsuarioId { get; set; }
	public virtual Sala Sala { get; set; } = null!;
	public virtual Usuario Usuario { get; set; } = null!;

}
