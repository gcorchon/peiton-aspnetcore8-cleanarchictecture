namespace Peiton.Core.Entities
{
    public class Deuda
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public string Concepto { get; set; } = null!;
		public decimal Importe { get; set; }
		public int Ano { get; set; }
		public DateTime Fecha { get; set; }
		public string? Observaciones { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}