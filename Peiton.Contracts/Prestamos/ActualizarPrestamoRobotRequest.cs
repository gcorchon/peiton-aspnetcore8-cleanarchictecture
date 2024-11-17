namespace Peiton.Contracts.Prestamos;

public class ActualizarPrestamoRobotRequest
{
    public bool Baja { get; set; }
    public DateTime? FechaBaja { get; set; }
    public int? TipoPrestamoId { get; set; }
    public string? Porcentaje { get; set; }
    public DateTime? FechaInicio { get; set; }
}