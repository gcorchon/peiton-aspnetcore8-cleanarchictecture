namespace Peiton.Core.Entities;
public class Inmueble
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public string? Llave { get; set; }
	public int TipoViaId { get; set; }
	public string NombreVia { get; set; } = null!;
	public string? Numero { get; set; }
	public string? Portal { get; set; }
	public string? Escalera { get; set; }
	public string? Piso { get; set; }
	public string? Puerta { get; set; }
	public string? CodigoPostal { get; set; }
	public string? Municipio { get; set; }
	public string? Barrio { get; set; }
	public int? DistritoId { get; set; }
	public int ProvinciaId { get; set; }
	public string? DireccionCompleta { get; set; }
	public string? RegistroCiudad { get; set; }
	public string? RegistroNumero { get; set; }
	public string? RegistroInscripcionReferencia { get; set; }
	public string? RegistroReferenciaCatastral { get; set; }
	public int TipoInmuebleId { get; set; }
	public string? Superficie { get; set; }
	public int? NumeroHabitaciones { get; set; }
	public int UtilizacionId { get; set; }
	public string? Observaciones { get; set; }
	public int? AgenteArrendadoId { get; set; }
	public int? AgenteVentaId { get; set; }
	public int? ValoracionId { get; set; }
	public DateTime? FechaEmbargo { get; set; }
	public DateTime? FechaVenta { get; set; }
	public decimal? ImporteVenta { get; set; }
	public int? AgenteDeshaucioId { get; set; }
	public int? AgenteHerenciaId { get; set; }
	public int? AgentePendienteValoracionId { get; set; }
	public int? AgenteProcesoRegularizacionId { get; set; }
	public string? RentaEstimada { get; set; }
	public DateTime? FechaExtincion { get; set; }
	public decimal? ImporteExtincion { get; set; }
	public int? AgenteExtincionId { get; set; }
	public bool Ivima { get; set; }
	public DateTime? FechaFinArrendamiento { get; set; }
	public int? AgenteCompraId { get; set; }
	public DateTime? FechaCompra { get; set; }
	public decimal? ImporteCompra { get; set; }
	public int? AgenteProcesoCompraId { get; set; }
	public DateTime? FechaAdquisicion { get; set; }
	public decimal? ImporteAdquisicion { get; set; }
	public int? InmuebleFuncionarioId { get; set; }
	public virtual Agente? AgenteDeshaucio { get; set; }
	public virtual AgenteArrendamiento? AgenteArrendado { get; set; }
	public virtual Agente? AgenteVenta { get; set; }
	public virtual Agente? AgenteHerencia { get; set; }
	public virtual Agente? AgentePendienteValoracion { get; set; }
	public virtual Agente? AgenteProcesoRegularizacion { get; set; }
	public virtual Distrito? Distrito { get; set; }
	public virtual InmuebleFuncionario? InmuebleFuncionario { get; set; }
	public virtual Provincia Provincia { get; set; } = null!;
	public virtual TipoInmueble TipoInmueble { get; set; } = null!;
	public virtual TipoVia TipoVia { get; set; } = null!;
	public virtual Tutelado Tutelado { get; set; } = null!;
	public virtual Utilizacion Utilizacion { get; set; } = null!;
	public virtual Valoracion? Valoracion { get; set; }
	public virtual ICollection<AvisoTributario> AvisosTributarios { get; } = new List<AvisoTributario>();
	/* public virtual ICollection<InmuebleAnejo> InmueblesAnejos { get; } = new List<InmuebleAnejo>(); */
	public virtual ICollection<InmuebleAutorizacion> InmueblesAutorizaciones { get; } = new List<InmuebleAutorizacion>();
	/* public virtual ICollection<InmuebleAviso> InmueblesAvisos { get; } = new List<InmuebleAviso>(); */
	/* public virtual ICollection<InmuebleSolicitudAlquilerVenta> InmueblesSolicitudesAlquileresVentas { get; } = new List<InmuebleSolicitudAlquilerVenta>(); */
	public virtual ICollection<InmuebleTasacion> InmueblesTasaciones { get; } = new List<InmuebleTasacion>();
	/* public virtual ICollection<InmuebleTipoTitularidad> InmueblesTiposTitularidades { get; } = new List<InmuebleTipoTitularidad>(); */
	/* public virtual ICollection<NotaSimple> NotasSimples { get; } = new List<NotaSimple>(); */
	/* public virtual ICollection<SeguroContratado> SegurosContratados { get; } = new List<SeguroContratado>(); */
	/* public virtual ICollection<UtilizacionOpcion> UtilizacionesOpciones { get; } = new List<UtilizacionOpcion>(); */
}
