namespace Peiton.Contracts.Quejas;

public class QuejaListItem
{

    public int Id { get; set; }
    public string Expediente { get; set; } = null!;
    public DateTime FechaEntrada { get; set; }
    public DateTime? FechaCierre { get; set; }
    public int? DiasTranscurridos { get; set; }
    public string TipoDenunciante { get; set; } = null!;
    public string Denunciante { get; set; } = null!;
    public bool ActuacionPendiente { get; set; }
}


