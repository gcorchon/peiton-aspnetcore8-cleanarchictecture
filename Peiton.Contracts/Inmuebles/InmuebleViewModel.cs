namespace Peiton.Contracts.Inmuebles;

public class InmuebleViewModel
{
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
}