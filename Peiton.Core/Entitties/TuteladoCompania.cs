namespace Peiton.Core.Entities;
public class TuteladoCompania
{
	public int TuteladoId { get; set; }
	public int CompaniaId { get; set; }
	public string? Numero { get; set; }
	public virtual Compania Compania { get; set; } = null!;
	public virtual Tutelado Tutelado { get; set; } = null!;

}
