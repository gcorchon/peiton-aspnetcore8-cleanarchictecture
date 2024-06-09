namespace Peiton.Core.Entities
{
    public class AccountTransaction
	{
		public int Id { get; set; }
		public int AccountId { get; set; }
		public string? Description { get; set; }
		public string? Payee { get; set; }
		public string? Payer { get; set; }
		public DateTime OperationDate { get; set; }
		public DateTime ValueDate { get; set; }
		public decimal Quantity { get; set; }
		public string? Reference { get; set; }
		public string? TransactionType { get; set; }
		public DateTime Fecha { get; set; }
		public int? CategoriaId { get; set; }
		public int? RuleId { get; set; }
		public string? AfterbanksTransactionId { get; set; }
		public string Origen { get; set; } = null!;
		public virtual Account Account { get; set; }= null!;
		public virtual Categoria? Categoria { get; set; }
		public virtual Rule? Rule { get; set; }

	}
}