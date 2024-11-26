namespace Peiton.Contracts.ProductosBancarios;

public class ProductoCertificado
{
    public DateTime Fecha { get; set; }
    public decimal Importe { get; set; }
    public string Numero { get; set; } = null!;
    public string Tipo { get; set; } = null!;
}