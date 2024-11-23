namespace Peiton.Contracts.ProductosBancarios;

public class EntidadPosicionGlobalViewModel
{
    public string Descripcion { get; set; } = null!;
    public string? CssClass { get; set; } = null!;
    public IEnumerable<ProductoBancarioPosicionGlobalViewModel> Accounts { get; set; } = [];
    public IEnumerable<ProductoBancarioPosicionGlobalViewModel> Funds { get; set; } = [];
    public IEnumerable<ProductoBancarioPosicionGlobalViewModel> Deposits { get; set; } = [];
    public IEnumerable<ProductoBancarioPosicionGlobalViewModel> Shares { get; set; } = [];
}