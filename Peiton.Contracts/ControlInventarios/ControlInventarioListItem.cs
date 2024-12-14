namespace Peiton.Contracts.ControlInventarios;

public class ControlInventarioListItem
{
    public int Id { get; set; }
    public string? Nombramiento { get; set; }
    public string? EstadoInventario { get; set; }
    public DateTime? FechaSalida { get; set; }
    public string? EstadoAprobacionInventario { get; set; }
    public DateTime? FechaAprobacion { get; set; }

}