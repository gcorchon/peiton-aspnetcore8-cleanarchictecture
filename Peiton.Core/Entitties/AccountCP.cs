namespace Peiton.Core.Entities
{
    public class AccountCP
	{
		public int Id { get; set; }
		public int CredencialCPId { get; set; }
		public DateTime Fecha { get; set; }
		public string? WebAlias { get; set; }
		public decimal? Saldo { get; set; }
		public DateTime? FechaSaldo { get; set; }
		public DateTime? FechaBaja { get; set; }
		public bool Baja { get; set; }
		public string? Iban { get; set; }
		public string Origen { get; set; } = null!;
		public virtual CredencialCP CredencialCP { get; set; }= null!;
		/* public virtual ICollection<AccountTransactionCP> AccountsTransactionsCP { get; } = new List<AccountTransactionCP>(); */

	}
}