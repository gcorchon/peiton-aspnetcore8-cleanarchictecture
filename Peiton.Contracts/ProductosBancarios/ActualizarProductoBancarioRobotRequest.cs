namespace Peiton.Contracts.ProductosBancarios;

public class ActualizarProductoBancarioRobotRequest
{
    public bool Baja { get; set; }
    public DateTime? FechaBaja { get; set; }
    public int? TipoProductoId { get; set; }
    public string? Titularidad { get; set; }
    public string? Observaciones { get; set; }
}