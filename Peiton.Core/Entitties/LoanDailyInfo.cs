namespace Peiton.Core.Entities
{
    public class LoanDailyInfo
	{
		public int LoanId { get; set; }
		public DateTime Fecha { get; set; }
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
		public virtual Loan Loan { get; set; }= null!;

	}
}