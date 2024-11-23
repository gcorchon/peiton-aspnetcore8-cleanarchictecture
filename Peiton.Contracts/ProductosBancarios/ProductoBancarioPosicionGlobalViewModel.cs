namespace Peiton.Contracts.ProductosBancarios;

public class ProductoBancarioPosicionGlobalViewModel
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Identificacion { get; set; } = null!;
    public decimal Saldo { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime? UltimaActualizacion { get; set; }
    public DateTime? FechaBaja { get; set; }
    public bool Baja { get; set; }
    public string Origen { get; set; } = null!;
}