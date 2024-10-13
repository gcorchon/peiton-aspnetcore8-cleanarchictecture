namespace Peiton.Core.Entities;
public class AppMovilRegistroDiario
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public DateTime Fecha { get; set; }
	public int? AppMovilEstadoAnimoId { get; set; }
	public string? TareasHoy { get; set; }
	public string? TareasAyer { get; set; }
	public string? Selfie { get; set; }
	public string? Comentario { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;
	public virtual AppMovilEstadoAnimo? AppMovilEstadoAnimo { get; set; }

}
