namespace Peiton.Contracts.Quejas;

public class QuejasFilter
{
    public string? Expediente { get; set; }
    public string? FechaEntrada { get; set; }
    public string? FechaCierre { get; set; }
    public int? DiasTranscurridos { get; set; }
    public int? TipoDenuncianteId { get; set; }
    public string? Denunciante { get; set; }
    public bool? ActuacionPendiente { get; set; }
}
