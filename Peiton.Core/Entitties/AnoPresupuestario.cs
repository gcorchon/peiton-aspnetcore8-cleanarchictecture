namespace Peiton.Core.Entities
{
    public class AnoPresupuestario
	{
		public int Ano { get; set; }
		public string Descripcion { get; set; } = null!;
		public DateTime FechaAlta { get; set; }
		public DateTime? FechaModificacion { get; set; }
		public DateTime? FechaBaja { get; set; }
		public decimal SaldoInicialCaja { get; set; }
		public decimal SaldoInicialBanco { get; set; }

		/* public virtual ICollection<Capitulo> Capitulos { get; } = new List<Capitulo>(); */

	}
}