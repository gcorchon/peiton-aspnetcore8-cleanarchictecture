namespace Peiton.Core.Entities;
public class EfectoPublico
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public int EntidadFinancieraId { get; set; }
	public string TipoProducto { get; set; } = null!;
	public string Identificacion { get; set; } = null!;
	public decimal Valoracion { get; set; }
	public DateTime Fecha { get; set; }
	public virtual EntidadFinanciera EntidadFinanciera { get; set; } = null!;
	public virtual Tutelado Tutelado { get; set; } = null!;

}
