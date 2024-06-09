namespace Peiton.Core.Entities
{
    public class Fund
	{
		public int Id { get; set; }
		public int CredencialId { get; set; }
		public string AccountNumber { get; set; } = null!;
		public string? FundName { get; set; }
		public string? Number { get; set; }
		public string? WebAlias { get; set; }
		public string? Titularidad { get; set; }
		public decimal? Saldo { get; set; }
		public DateTime? FechaSaldo { get; set; }
		public string? Observaciones { get; set; }
		public DateTime? FechaBaja { get; set; }
		public bool Baja { get; set; }
		public DateTime Fecha { get; set; }
		public string? CustomWebAlias { get; set; }
		public string Origen { get; set; } = null!;
		public virtual Credencial Credencial { get; set; }= null!;
		/* public virtual ICollection<FundDailyInfo> FundesDailyInfos { get; } = new List<FundDailyInfo>(); */

	}
}