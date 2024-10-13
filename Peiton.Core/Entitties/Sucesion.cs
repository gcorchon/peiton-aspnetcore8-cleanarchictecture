namespace Peiton.Core.Entities;
public class Sucesion
{
	public int Id { get; set; }
	public int UsuarioId { get; set; }
	public int TuteladoId { get; set; }
	public int SucesionTipoId { get; set; }
	public string Origen { get; set; } = null!;
	public DateTime? FechaEscritura { get; set; }
	public bool Solicitada { get; set; }
	public bool Autorizada { get; set; }
	public bool Firme { get; set; }
	public DateTime? FechaSolicitud { get; set; }
	public DateTime? FechaAutorizacion { get; set; }
	public DateTime? FechaFirmeza { get; set; }
	public string? Observaciones { get; set; }
	public DateTime Fecha { get; set; }
	public virtual SucesionTipo SucesionTipo { get; set; } = null!;
	public virtual Tutelado Tutelado { get; set; } = null!;
	public virtual Usuario Usuario { get; set; } = null!;

}
