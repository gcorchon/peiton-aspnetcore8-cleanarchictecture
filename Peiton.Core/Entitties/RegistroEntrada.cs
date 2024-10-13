namespace Peiton.Core.Entities;
public class RegistroEntrada
{
	public int Id { get; set; }
	public string Dni { get; set; } = null!;
	public bool Tutelado { get; set; }
	public string Nombre { get; set; } = null!;
	public string Personas { get; set; } = null!;
	public int MotivoEntradaId { get; set; }
	public DateTime Fecha { get; set; }
	public string HoraEntrada { get; set; } = null!;
	public string? HoraSalida { get; set; }
	public string? Observaciones { get; set; }
	public virtual MotivoEntrada MotivoEntrada { get; set; } = null!;

}
