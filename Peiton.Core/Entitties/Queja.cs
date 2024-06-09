namespace Peiton.Core.Entities
{
    public class Queja
	{
		public int Id { get; set; }
		public int QuejaTipoId { get; set; }
		public string Expediente { get; set; } = null!;
		public int TuteladoId { get; set; }
		public int QuejaTipoDenuncianteId { get; set; }
		public int? UsuarioId { get; set; }
		public DateTime FechaEntrada { get; set; }
		public DateTime? FechaCierre { get; set; }
		public int? DiasTranscurridos { get; set; }
		public string? NombreDenunciante { get; set; }
		public string? DNIDenunciante { get; set; }
		public string? Resumen { get; set; }
		public int? QuejaTipoCierreId { get; set; }
		public bool ActuacionPendiente { get; set; }
		public string? Comentarios { get; set; }
		public string? numero { get; set; }
		public int? UsuarioResponsableId { get; set; }
		public string? Documento { get; set; }
		public virtual QuejaTipo QuejaTipo { get; set; }= null!;
		public virtual QuejaTipoCierre? QuejaTipoCierre { get; set; }
		public virtual QuejaTipoDenunciante QuejaTipoDenunciante { get; set; }= null!;
		public virtual Tutelado Tutelado { get; set; }= null!;
		public virtual Usuario? Usuario { get; set; }
		public virtual Usuario? UsuarioResponsable { get; set; }

		/* public virtual ICollection<QuejaMotivo> QuejasMotivos { get; } = new List<QuejaMotivo>(); */
	}
}