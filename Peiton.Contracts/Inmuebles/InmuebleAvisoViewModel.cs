namespace Peiton.Contracts.Inmuebles
{
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

    public class TuteladoAvisoInmueble
    {
        public string NombreCompleto { get; set; } = null!;
        public string DNI { get; set; } = null!;
        public string Nombramiento { get; set; } = null!; //

        public IEnumerable<SeguroHogar> SegurosHogar { get; set; } = new List<SeguroHogar>(); //
    }

    public class SeguroHogar
    {
        public string? TipoSeguro { get; set; } //
        public string? Seguro { get; set; } //
        public string? NumeroPoliza { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Observaciones { get; set; }
        public bool Baja { get; set; }
    }

    public class InmuebleInfo
    {
        public string DireccionCompleta { get; set; } = null!;
        public string? Llave { get; set; }

        public TuteladoAvisoInmueble Tutelado { get; set; } = null!;
    }

    public class TipoAviso
    {
        public string Descripcion { get; set; } = null!;
        public decimal? Importe { get; set; } //
    }


}
