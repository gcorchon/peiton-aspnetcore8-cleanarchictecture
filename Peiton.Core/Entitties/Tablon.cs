namespace Peiton.Core.Entities
{
    public class Tablon
	{
		public int Id { get; set; }
		public string Texto { get; set; } = null!;
		public DateTime Fecha { get; set; }
		public int UsuarioId { get; set; }
		public virtual Usuario Usuario { get; set; }= null!;

	}
}