namespace Peiton.Contracts.ProductosBancarios;

public class CertificadoViewModel
{
    public string Tutelado { get; set; } = null!;
    public string DNI { get; set; } = null!;
    public string Cabecera { get; set; } = null!;
    public List<ProductoCertificado> Productos = [];
}