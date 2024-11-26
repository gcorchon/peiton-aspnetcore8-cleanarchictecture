using Peiton.Contracts.Common;

namespace Peiton.Contracts.ProductosBancarios;

public class ProductoBancarioListItem
{
    public int Id { get; set; }
    public bool Manual { get; set; }
    public string TipoProducto { get; set; } = null!;
    public ListItem EntidadFinanciera { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Identificacion { get; set; } = null!;
    public string Titularidad { get; set; } = null!;
    public bool Baja { get; set; }
    public DateTime? FechaBaja { get; set; }
}