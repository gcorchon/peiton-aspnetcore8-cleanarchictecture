namespace Peiton.Contracts.Vales;
public class GuardarValeRequest
{
    public decimal Importe { get; set; }
    public string? Observaciones { get; set; } = "";
    public string[] Archivos { get; set; } = [];
}