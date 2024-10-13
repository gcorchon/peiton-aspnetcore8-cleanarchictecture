namespace Peiton.Core.Entities;
public class Evento
{
	public int Id { get; set; }
	public int UsuarioId { get; set; }
	public string Lugar { get; set; } = null!;
	public string Descripcion { get; set; } = null!;
	public DateTime Fecha { get; set; }
	public DateTime? FechaFin { get; set; }
	public int? CategoriaAgendaId { get; set; }
	public int? AgendaAreaActuacionId { get; set; }
	public int? AgendaActuacionId { get; set; }
	public int? AgendaId { get; set; }
	public int? TuteladoId { get; set; }
	public int? RecordatorioId { get; set; }
	public DateTime? FechaRecordatorio { get; set; }
	public bool Recordado { get; set; }
	public int? RepeticionCantidad { get; set; }
	public int? RepeticionPeriodo { get; set; }
	public int? EventoId { get; set; }
	public bool Repetido { get; set; }
	public string? OtrosInvitados { get; set; }
	public virtual Usuario Usuario { get; set; } = null!;
	public virtual Agenda? Agenda { get; set; }
	public virtual AgendaActuacion? AgendaActuacion { get; set; }
	public virtual AgendaAreaActuacion? AgendaAreaActuacion { get; set; }
	public virtual CategoriaAgenda? CategoriaAgenda { get; set; }
	public virtual Evento? EventoPadre { get; set; }
	public virtual Recordatorio? Recordatorio { get; set; }
	public virtual Tutelado? Tutelado { get; set; }
	/* public virtual ICollection<Evento> Eventos { get; } = new List<Evento>(); */
	/* public virtual ICollection<Grupo> Grupos { get; } = new List<Grupo>(); */
	/* public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>(); */
}
