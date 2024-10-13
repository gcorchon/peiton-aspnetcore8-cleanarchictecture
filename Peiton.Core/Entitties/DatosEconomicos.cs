namespace Peiton.Core.Entities;
public class DatosEconomicos
{
	public int TuteladoId { get; set; }
	public string? Derechos { get; set; }
	public string? OtrosBienes { get; set; }
	public string? OtrosDatos { get; set; }
	public string? OtrasDeudas { get; set; }
	public bool ExentoIRPF { get; set; }
	public string? DerechosDeCredito { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;

}
