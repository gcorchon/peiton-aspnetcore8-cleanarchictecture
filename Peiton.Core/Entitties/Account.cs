namespace Peiton.Core.Entities
{
    public class Account
	{
		public int Id { get; set; }
		public int CredencialId { get; set; }
		public DateTime Fecha { get; set; }
		public string? WebAlias { get; set; }
		public string? Titularidad { get; set; }
		public decimal? Saldo { get; set; }
		public DateTime? FechaSaldo { get; set; }
		public DateTime? FechaBaja { get; set; }
		public string? Observaciones { get; set; }
		public bool Baja { get; set; }
		public bool LibreDisposicion { get; set; }
		public string? CustomWebAlias { get; set; }
		public string? Iban { get; set; }
		public string Origen { get; set; } = null!;
		public virtual Credencial Credencial { get; set; }= null!;
		/* public virtual ICollection<AccountDailyBalance> AccountsDailyBalances { get; } = new List<AccountDailyBalance>(); */
		/* public virtual ICollection<AccountDailyBalanceReal> AccountsDailyBalancesReales { get; } = new List<AccountDailyBalanceReal>(); */
		/* public virtual ICollection<AccountTransaction> AccountsTransactions { get; } = new List<AccountTransaction>(); */

	}
}