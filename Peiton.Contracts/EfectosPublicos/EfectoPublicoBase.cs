namespace Peiton.Contracts.EfectosPublicos;

public class EfectoPublicoBase
{
    public string TipoProducto { get; set; } = null!;
    public string Identificacion { get; set; } = null!;
    public decimal Valoracion { get; set; }
}