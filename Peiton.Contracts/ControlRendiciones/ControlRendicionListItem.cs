namespace Peiton.Contracts.ControlRendiciones;

public class ControlRendicionListItem
{
    public int Id { get; set; }
    public string? Nombramiento { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string? EstadoAprobacionRendicion { get; set; }
    public DateTime? FechaSalidaAMTA { get; set; }

    public string? EstadoRetribucion { get; set; }
    public DateTime? FechaResolucion { get; set; }


}