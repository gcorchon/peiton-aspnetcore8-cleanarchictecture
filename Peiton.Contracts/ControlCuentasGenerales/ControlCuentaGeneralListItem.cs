namespace Peiton.Contracts.ControlCuentasGenerales;

public class ControlCuentaGeneralListItem
{
    public int Id { get; set; }
    public string? Nombramiento { get; set; } = null!;
    public string? TipoCGJ { get; set; }
    public string? EstadoAprobacionCGJ { get; set; }
    public DateTime? FechaSalidaAMTA { get; set; }
    public DateTime? FechaFinPresentada { get; set; }

}