namespace Peiton.Core.Entities;
public class TuteladoRelacionConvivencional
{
	public int TuteladoId { get; set; }
	public int Orden { get; set; }
	public string? ConQuien { get; set; }
	public int? TipoRelacionConvivencionalId { get; set; }
	public virtual TipoRelacionConvivencional? TipoRelacionConvivencional { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;

}
