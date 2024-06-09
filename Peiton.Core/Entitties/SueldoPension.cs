namespace Peiton.Core.Entities
{
    public class SueldoPension
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public decimal Importe { get; set; }
		public int NumeroPagas { get; set; }
		public DateTime Fecha { get; set; }
		public string? Observaciones { get; set; }
		public int Ano { get; set; }
		public int TipoPensionId { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}