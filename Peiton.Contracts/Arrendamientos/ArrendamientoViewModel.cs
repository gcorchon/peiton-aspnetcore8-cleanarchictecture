namespace Peiton.Contracts.Arrendamientos;

public class ArrendamientoViewModel
{
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
    public string? RegistroCiudad { get; set; }
    public string? RegistroNumero { get; set; }
    public string? RegistroInscripcionReferencia { get; set; }
    public string? RegistroReferenciaCatastral { get; set; }
    public string? Observaciones { get; set; }
    public DateTime? FechaInicioArrendamiento { get; set; }
    public DateTime? FechaFinArrendamiento { get; set; }
    public DateTime? UltimaActualizacionArrendamiento { get; set; }
    public decimal? RentaMensualArrendamiento { get; set; }
    public bool? FianzaArrendamiento { get; set; }
    public bool? AvalBancarioArrendamiento { get; set; }
    public int? AgenteArrendamientoId { get; set; }
}