namespace Peiton.Core.Entities
{
    public class AppMovilTuteladoRecompensa
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public int AppMovilRecompensaId { get; set; }
		public bool Aprobada { get; set; }
		public DateTime Fecha { get; set; }
		public DateTime? FechaAprobacion { get; set; }
		public bool Disfrutada { get; set; }
		public bool Notificada { get; set; }
		public int? AppMovilVoluntarioId { get; set; }
		public string? Observaciones { get; set; }
		public virtual AppMovilRecompensa AppMovilRecompensa { get; set; }= null!;
		public virtual Tutelado Tutelado { get; set; }= null!;
		public virtual AppMovilVoluntario? AppMovilVoluntario { get; set; }

	}
}