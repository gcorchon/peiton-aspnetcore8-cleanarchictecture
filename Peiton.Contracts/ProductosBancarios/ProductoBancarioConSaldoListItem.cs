using Peiton.Contracts.Common;

namespace Peiton.Contracts.ProductosBancarios;

public class ProductoBancarioConSaldoListItem
{
    public int Id { get; set; }
    public bool Manual { get; set; }
    public int EntidadFinancieraId { get; set; }
    public string EntidadFinancieraDescripcion { get; set; } = null!;
    public int TipoProductoId { get; set; }
    public string TipoProductoDescripcion { get; set; } = null!;
    public string Identificacion { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Titularidad { get; set; } = null!;
    public decimal Saldo { get; set; }
    public DateTime FechaSaldo { get; set; }
    public bool Baja { get; set; }
    public DateTime? FechaBaja { get; set; }
    public string? Observaciones { get; set; }
    public DateTime Fecha { get; set; }

}