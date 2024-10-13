namespace Peiton.Core.Entities;
public class TuteladoAllegado
{
	public int TuteladoId { get; set; }
	public int AllegadoId { get; set; }
	public int Orden { get; set; }
	public int? RelacionAllegadoId { get; set; }
	public string? Numero { get; set; }
	public bool Conflictiva { get; set; }
	public virtual Allegado Allegado { get; set; } = null!;
	public virtual RelacionAllegado? RelacionAllegado { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;

}
