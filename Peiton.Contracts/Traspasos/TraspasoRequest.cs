namespace Peiton.Contracts.Traspasos;

public class TraspasoRequest
{
    public int OrigenId { get; set; }
    public int DestinoId { get; set; }
    public string Trabajador { get; set; } = null!;
}