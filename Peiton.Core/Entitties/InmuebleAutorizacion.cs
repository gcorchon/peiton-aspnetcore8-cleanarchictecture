namespace Peiton.Core.Entities
{
    public class InmuebleAutorizacion
	{
		public int Id { get; set; }
		public int InmuebleId { get; set; }
		public int InmuebleMotivoAutorizacionId { get; set; }
		public string Descripcion { get; set; } = null!;
		public int UsuarioId { get; set; }
		public bool Autorizado { get; set; }
		public bool Presentado { get; set; }
		public bool Firme { get; set; }
		public DateTime? FechaAutorizado { get; set; }
		public DateTime? FechaPresentado { get; set; }
		public DateTime? FechaFirme { get; set; }
		public string? Observaciones { get; set; }
		public DateTime? Fecha { get; set; }
		public bool Archivo { get; set; }
		public virtual Inmueble Inmueble { get; set; }= null!;
		public virtual InmuebleMotivoAutorizacion InmuebleMotivoAutorizacion { get; set; }= null!;
		public virtual Usuario Usuario { get; set; }= null!;

	}
}