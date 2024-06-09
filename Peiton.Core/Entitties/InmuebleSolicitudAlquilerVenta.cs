namespace Peiton.Core.Entities
{
    public class InmuebleSolicitudAlquilerVenta
	{
		public int Id { get; set; }
		public int InmuebleId { get; set; }
		public string? Nombre { get; set; }
		public string? Contacto { get; set; }
		public string? Comentarios { get; set; }
		public string? ObservacionesDepartamentoInmuebles { get; set; }
		public int? OcupacionId { get; set; }
		public int? UsuarioId { get; set; }
		public int Estado { get; set; }
		public DateTime Fecha { get; set; }
		public string Tipo { get; set; } = null!;
		public string? Observaciones { get; set; }
		public virtual Inmueble Inmueble { get; set; }= null!;
		public virtual Ocupacion? Ocupacion { get; set; }
		public virtual Usuario? Usuario { get; set; }

	}
}