namespace Peiton.Core.Entities
{
    public class Recordatorio
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;

		/* public virtual ICollection<Evento> Eventos { get; } = new List<Evento>(); */

	}
}