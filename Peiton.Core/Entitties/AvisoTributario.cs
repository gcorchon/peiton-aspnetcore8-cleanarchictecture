namespace Peiton.Core.Entities
{
    public class AvisoTributario
	{
		public int Id { get; set; }
		public int UsuarioId { get; set; }
		public int TuteladoId { get; set; }
		public int TipoAvisoTributarioId { get; set; }
		public string? Comentarios { get; set; }
		public int? InmuebleId { get; set; }
		public int? Ano { get; set; }
		public DateTime Fecha { get; set; }
		public bool Resuelto { get; set; }
		public DateTime? FechaResolucion { get; set; }
		public bool EnTramite { get; set; }
		public string? ComentariosDepartamentoTributario { get; set; }
		public virtual Inmueble? Inmueble { get; set; }
		public virtual TipoAvisoTributario TipoAvisoTributario { get; set; }= null!;
		public virtual Tutelado Tutelado { get; set; }= null!;
		public virtual Usuario Usuario { get; set; }= null!;

	}
}