namespace Peiton.Core.Entities
{
    public class SMS
	{
		public int Id { get; set; }
		public string Texto { get; set; } = null!;
		public string Data { get; set; } = null!;
		public DateTime Fecha { get; set; }
		public bool Usado { get; set; }

	}
}