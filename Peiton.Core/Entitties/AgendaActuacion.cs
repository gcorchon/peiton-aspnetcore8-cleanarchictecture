namespace Peiton.Core.Entities
{
    public class AgendaActuacion
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public int AgendaAreaActuacionId { get; set; }
		public virtual AgendaAreaActuacion AgendaAreaActuacion { get; set; }= null!;
		/* public virtual ICollection<Agenda> Entradas { get; } = new List<Agenda>(); */
		/* public virtual ICollection<Evento> Eventos { get; } = new List<Evento>(); */
		/* public virtual ICollection<UrgenciaAgenda> UrgenciasEntradas { get; } = new List<UrgenciaAgenda>(); */

	}
}