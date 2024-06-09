namespace Peiton.Core.Entities
{
    public class ProductoManual
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public int EntidadFinancieraId { get; set; }
		public int TipoProductoId { get; set; }
		public string Nombre { get; set; } = null!;
		public string Identificacion { get; set; } = null!;
		public decimal Saldo { get; set; }
		public DateTime? FechaSaldo { get; set; }
		public string? Observaciones { get; set; }
		public bool Baja { get; set; }
		public DateTime? FechaBaja { get; set; }
		public DateTime Fecha { get; set; }
		public string? Titularidad { get; set; }
		public string? CustomWebAlias { get; set; }
		public virtual EntidadFinanciera EntidadFinanciera { get; set; }= null!;
		public virtual Tutelado Tutelado { get; set; }= null!;
		public virtual TipoProducto TipoProducto { get; set; }= null!;

	}
}