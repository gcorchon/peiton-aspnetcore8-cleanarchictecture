namespace Peiton.Core.Entities
{
    public class AccountDailyBalanceReal
	{
		public int AccountId { get; set; }
		public DateTime Fecha { get; set; }
		public decimal Balance { get; set; }
		public virtual Account Account { get; set; }= null!;

	}
}