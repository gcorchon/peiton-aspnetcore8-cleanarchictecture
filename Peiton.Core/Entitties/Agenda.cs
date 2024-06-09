namespace Peiton.Core.Entities
{
    public class Agenda
	{
		public int Id { get; set; }
		public int UsuarioId { get; set; }
		public int CategoriaAgendaId { get; set; }
		public int TuteladoId { get; set; }
		public string Descripcion { get; set; } = null!;
		public DateTime Fecha { get; set; }
		public int? AgendaActuacionId { get; set; }
		public bool? Realizada { get; set; }
		public int? Minutos { get; set; }
		public int? AgendaAreaActuacionId { get; set; }
		public DateTime? FechaActuacion { get; set; }
		public bool Desacuerdo { get; set; }
		public string? AlertasEnviadas { get; set; }
		public virtual AgendaAreaActuacion? AgendaAreaActuacion { get; set; }
		public virtual CategoriaAgenda CategoriaAgenda { get; set; }= null!;
		public virtual Tutelado Tutelado { get; set; }= null!;
		public virtual Usuario Usuario { get; set; }= null!;
		public virtual AgendaActuacion? AgendaActuacion { get; set; }
		/* public virtual ICollection<Evento> Eventos { get; } = new List<Evento>(); */

	}
}