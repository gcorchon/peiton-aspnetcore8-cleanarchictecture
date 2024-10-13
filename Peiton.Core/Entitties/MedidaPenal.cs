namespace Peiton.Core.Entities;
public class MedidaPenal
{
	public int TuteladoId { get; set; }
	public int Orden { get; set; }
	public int JuzgadoId { get; set; }
	public string? NumeroProcedimiento { get; set; }
	public DateTime? FechaInicio { get; set; }
	public DateTime? FechaFin { get; set; }
	public int? MedidaPenalTipoId { get; set; }
	public int? MedidaPenalNaturalezaId { get; set; }
	public int? MedidaPenalMedidaId { get; set; }
	public string? Observaciones { get; set; }
	public bool Terminado { get; set; }
	public bool Suspendida { get; set; }
	public virtual Juzgado Juzgado { get; set; } = null!;
	public virtual MedidaPenalMedida? MedidaPenalMedida { get; set; }
	public virtual MedidaPenalNaturaleza? MedidaPenalNaturaleza { get; set; }
	public virtual MedidaPenalTipo? MedidaPenalTipo { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;

}
