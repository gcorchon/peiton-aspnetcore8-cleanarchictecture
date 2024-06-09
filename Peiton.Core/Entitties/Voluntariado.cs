namespace Peiton.Core.Entities
{
    public class Voluntariado
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public int UsuarioId { get; set; }
		public DateTime FechaAviso { get; set; }
		public DateTime FechaActuacion { get; set; }
		public DateTime? FechaAceptacion { get; set; }
		public int VoluntariadoTipoId { get; set; }
		public string Asunto { get; set; } = null!;
		public string Detalle { get; set; } = null!;
		public int? VoluntarioId { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;
		public virtual Usuario Usuario { get; set; }= null!;
		public virtual Usuario? Voluntario { get; set; }
		public virtual VoluntariadoTipo VoluntariadoTipo { get; set; }= null!;

	}
}