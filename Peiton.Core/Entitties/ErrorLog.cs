namespace Peiton.Core.Entities
{
    public class ErrorLog
	{
		public int Id { get; set; }
		public string Message { get; set; } = null!;
		public string StackTrace { get; set; } = null!;
		public DateTime Fecha { get; set; }

	}
}