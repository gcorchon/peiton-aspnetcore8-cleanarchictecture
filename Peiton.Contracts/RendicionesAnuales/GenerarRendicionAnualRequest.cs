namespace Peiton.Contracts.RendicionesAnuales;

public class GenerarRendicionAnualRequest
{
    public int TuteladoId { get; set; }
    public DateTime Desde { get; set; }
    public DateTime Hasta { get; set; }
    public bool SolicitarRetribucion { get; set; }
    public int[] Archivos { get; set; } = [];
}