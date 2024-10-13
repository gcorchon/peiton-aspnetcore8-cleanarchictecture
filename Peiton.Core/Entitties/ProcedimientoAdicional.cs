namespace Peiton.Core.Entities;
public class ProcedimientoAdicional
{
	public int TuteladoId { get; set; }
	public int Orden { get; set; }
	public int JuzgadoId { get; set; }
	public int ProcedimientoId { get; set; }
	public string NumeroProcedimiento { get; set; } = null!;
	public int? AbogadoExternoId { get; set; }
	public int? AbogadoInternoId { get; set; }
	public int? TipoAbogado { get; set; }
	public bool Terminado { get; set; }
	public int? OrdenJurisdiccionalId { get; set; }
	public string? Observaciones { get; set; }
	public DateTime? FechaInicioInterno { get; set; }
	public virtual Juzgado Juzgado { get; set; } = null!;
	public virtual Procedimiento Procedimiento { get; set; } = null!;
	public virtual Tutelado Tutelado { get; set; } = null!;

}
