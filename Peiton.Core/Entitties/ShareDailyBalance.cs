namespace Peiton.Core.Entities
{
    public class ShareDailyBalance
	{
		public int ShareId { get; set; }
		public DateTime Fecha { get; set; }
		public decimal Balance { get; set; }
		public virtual Share Share { get; set; }= null!;

	}
}