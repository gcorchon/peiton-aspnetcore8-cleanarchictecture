namespace Peiton.Core.Entities
{
    public class MensajeTutelado
	{
		public int Id { get; set; }
		public string Asunto { get; set; } = null!;
		public string Cuerpo { get; set; } = null!;
		public DateTime Fecha { get; set; }
		public string Info { get; set; } = null!;

	}
}