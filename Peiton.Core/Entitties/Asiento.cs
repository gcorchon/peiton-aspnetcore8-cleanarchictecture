namespace Peiton.Core.Entities
{
	public class Asiento
	{
		public int Id { get; set; }
		public int? Numero { get; set; }
		public int? AccountTransactionCPId { get; set; }
		public int? CajaAMTAId { get; set; }
		public DateTime? FechaPago { get; set; }
		public DateTime? FechaAutorizacion { get; set; }
		public int PartidaId { get; set; }
		public string? Concepto { get; set; }
		public int? TipoMovimiento { get; set; }
		public decimal Importe { get; set; }
		public int? TipoPago { get; set; }
		public int? TuteladoId { get; set; }
		public int? ClienteId { get; set; }
		public int? FormaPagoId { get; set; }
		public virtual AccountTransactionCP? AccountTransactionCP { get; set; }
		public virtual FormaPago? FormaPago { get; set; }
		public virtual CajaAMTA? CajaAMTA { get; set; }
		public virtual Cliente? Cliente { get; set; }
		public virtual Partida Partida { get; set; } = null!;
		public virtual Tutelado? Tutelado { get; set; }
		public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();

	}
}