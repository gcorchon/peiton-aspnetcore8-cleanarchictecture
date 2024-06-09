namespace Peiton.Core.Entities
{
    public class Ausencia
	{
		public int Id { get; set; }
		public int UsuarioId { get; set; }
		public int? UsuarioSuplenteId { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime FechaFin { get; set; }
		public virtual Usuario Usuario { get; set; }= null!;
		public virtual Usuario? UsuarioSuplente { get; set; }

	}
}