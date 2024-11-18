namespace Peiton.Contracts.ProductosBancarios;

public class ProductoBancarioViewModel
{
    public int EntidadFinancieraId { get; set; }
    public int TipoProductoId { get; set; }
    public string Nombre { get; set; } = null!;
    public string Identificacion { get; set; } = null!;
    public string? Titularidad { get; set; } = null!;
    public bool Baja { get; set; }
    public DateTime? FechaBaja { get; set; }
    public decimal? Saldo { get; set; }
    public DateTime? FechaSaldo { get; set; }
    public string? Observaciones { get; set; }
}