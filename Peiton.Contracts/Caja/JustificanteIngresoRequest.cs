namespace Peiton.Contracts.Caja;

public class JustificanteIngresoRequest
{
    public int TuteladoId { get; set; }
    public DateTime FechaAutorizacion { get; set; }
    public string Concepto { get; set; } = null!;
    public decimal Importe { get; set; }
    public string? PrestadorDelServicio { get; set; }
}