namespace Peiton.Core.Entities
{
    public class Mensaje
	{
		public int Id { get; set; }
		public int? MensajeId { get; set; }
		public DateTime Fecha { get; set; }
		public int Usuario_DeId { get; set; }
		public int Usuario_ParaId { get; set; }
		public string Para { get; set; } = null!;
		public string ConCopia { get; set; } = null!;
		public string Asunto { get; set; } = null!;
		public string Cuerpo { get; set; } = null!;
		public bool Leido { get; set; }
		public bool Archivado { get; set; }
		public DateTime? FechaLectura { get; set; }
		public int? Dias { get; set; }
		public string? CssClass { get; set; }
		public virtual Mensaje? MensajePadre { get; set; }
		public virtual Usuario UsuarioDe { get; set; }= null!;
		public virtual Usuario UsuarioPara { get; set; }= null!;
		/* public virtual ICollection<Mensaje> Mensajes { get; } = new List<Mensaje>(); */
		/* public virtual ICollection<MensajeEnviado> MensajesEnviados { get; } = new List<MensajeEnviado>(); */

	}
}