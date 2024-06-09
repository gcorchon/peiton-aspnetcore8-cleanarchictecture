namespace Peiton.Core.Entities
{
    public class Loan
	{
		public int Id { get; set; }
		public int CredencialId { get; set; }
		public string? AccountNumber { get; set; }
		public string? AccountType { get; set; }
		public string? AliasEnabled { get; set; }
		public string? Bank { get; set; }
		public DateTime? BeginDate { get; set; }
		public string? Branch { get; set; }
		public string? ControlDigits { get; set; }
		public string? Currency { get; set; }
		public decimal? Debt { get; set; }
		public string? Deduction { get; set; }
		public DateTime? DeductionDate { get; set; }
		public string? DifferentialRate { get; set; }
		public DateTime? EndDate { get; set; }
		public decimal? InitialBalance { get; set; }
		public string? PartialDeprecRate { get; set; }
		public string? ReferentialKey { get; set; }
		public string? Secuential { get; set; }
		public string? TotalDeprecRate { get; set; }
		public string? ValueRate { get; set; }
		public string? WebAlias { get; set; }
		public bool Baja { get; set; }
		public DateTime? FechaBaja { get; set; }
		public DateTime Fecha { get; set; }
		public DateTime? UltimaActualizacion { get; set; }
		public string? Porcentaje { get; set; }
		public string? Observaciones { get; set; }
		public int? TipoPrestamoId { get; set; }
		public virtual Credencial Credencial { get; set; }= null!;
		/* public virtual ICollection<LoanDailyInfo> LoanesDailyInfos { get; } = new List<LoanDailyInfo>(); */

	}
}