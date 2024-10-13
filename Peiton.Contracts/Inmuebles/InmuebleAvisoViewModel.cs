namespace Peiton.Contracts.Inmuebles;
public class InmuebleAvisoViewModel
{
    public string? Nombre { get; set; }
    public string? Contacto { get; set; }
    public string? Comentarios { get; set; }
    public string? Observaciones { get; set; }
    public bool Urgente { get; set; }
    public bool SinRecursos { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime? FechaVisitaPrevia { get; set; }
    public DateTime? FechaVisitaGI { get; set; }
    public DateTime? FechaVisitaEmpresa { get; set; }
    public DateTime? FechaFinalizacion { get; set; }
    public string? InformeInicialGestionItinerante { get; set; }
    public string? ObservacionesDepartamentoAvisos { get; set; }
    public string? InformeFinalGestionItinerante { get; set; }
    public bool? CambioCerradura { get; set; }
    public bool? AccesoImposible { get; set; }
    public string? ObservacionesFacturacion { get; set; }
    public bool Resuelto { get; set; }
    public bool EnTramite { get; set; }
    public string Usuario { get; set; } = null!; //

    public InmuebleInfo Inmueble { get; set; } = null!; //
    public string? Ocupacion { get; set; } //

    public IEnumerable<TipoAviso> TiposAviso { get; set; } = new List<TipoAviso>(); //
    public IEnumerable<Coste> Costes { get; set; } = new List<Coste>(); //
}