namespace Peiton.Core.Entities;
public class InmuebleAviso
{
	public int Id { get; set; }
	public int InmuebleId { get; set; }
	public string? Nombre { get; set; }
	public string? Contacto { get; set; }
	public string? Comentarios { get; set; }
	public string? Observaciones { get; set; }
	public int? OcupacionId { get; set; }
	public bool Urgente { get; set; }
	public bool SinRecursos { get; set; }
	public DateTime Fecha { get; set; }
	public DateTime? FechaVisitaPrevia { get; set; }
	public DateTime? FechaVisitaGI { get; set; }
	public DateTime? FechaVisitaEmpresa { get; set; }
	public DateTime? FechaFinalizacion { get; set; }
	public int? UsuarioId { get; set; }
	public string? InformeInicialGestionItinerante { get; set; }
	public string? ObservacionesDepartamentoAvisos { get; set; }
	public string? InformeFinalGestionItinerante { get; set; }
	public bool? CambioCerradura { get; set; }
	public bool? AccesoImposible { get; set; }
	public string? ObservacionesFacturacion { get; set; }
	public bool Resuelto { get; set; }
	public bool EnTramite { get; set; }
	public virtual Inmueble Inmueble { get; set; } = null!;
	public virtual Ocupacion? Ocupacion { get; set; }
	public virtual Usuario Usuario { get; set; } = null!;
	public virtual ICollection<InmuebleAvisoCoste> InmuebleAvisosCostes { get; } = new List<InmuebleAvisoCoste>();
	public virtual ICollection<InmuebleTipoAviso> InmuebleTiposAvisos { get; } = new List<InmuebleTipoAviso>();

}
