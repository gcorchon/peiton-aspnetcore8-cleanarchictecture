namespace Peiton.Contracts.Asientos;

public class SaldosFilter
{
    public string? Tipo { get; set; }
    public string? NumeroCapitulo { get; set; }
    public string? NumeroPartida { get; set; }
    public string? Descripcion { get; set; }
    public string? Presupuesto { get; set; }
    public string? Ejecutado { get; set; }
    public string? Pendiente { get; set; }
    public string? PorcEjecutado { get; set; }
}