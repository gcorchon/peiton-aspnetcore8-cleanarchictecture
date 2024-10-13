namespace Peiton.Contracts.Inmuebles;
public class DocumentoPago
{
    public int CuentaSeleccionada { get; set; }
    public string? OtraCuentaTutelado { get; set; }
    public string? QuienPaga { get; set; } = null!;
    public int CuentaSeleccionadaEmpresa { get; set; }
    public string? OtraCuentaEmpresa { get; set; }
    public string? CuentaEmpresa { get; set; }
    public string? Observaciones { get; set; }
    public Coste? Coste { get; set; }
    public ListaCuentas? Cuentas { get; set; }
}
