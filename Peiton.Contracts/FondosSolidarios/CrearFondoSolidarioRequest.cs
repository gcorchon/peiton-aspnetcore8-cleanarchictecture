namespace Peiton.Contracts.FondosSolidarios;

public class CrearFondoSolidarioRequest
{
    public int TuteladoId { get; set; }
    public int FondoSolidarioTipoFondoId { get; set; }
    public int FondoSolidarioPeriodicidadId { get; set; }
    public int FondoSolidarioDestinoId { get; set; }
    public decimal Importe { get; set; }
    public string ObservacionesSolicitud { get; set; } = null!;
    public bool FamiliaContribuye { get; set; }
    public bool Recuperable { get; set; }
    public string? Archivo { get; set; }
    public string? Archivo2 { get; set; }
    public int? FondoSolidarioPadreId { get; set; }
}