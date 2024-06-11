namespace Peiton.Contracts.Asientos;

public class Saldo
{
    public string Tipo { get; set; } = "";
    public string NumeroCapitulo { get; set; } = "";
    public string? NumeroPartida { get; set; }
    public string Descripcion { get; set; } = "";
    public decimal Presupuesto { get; set; }
    public decimal? Ejecutado { get; set; }
    public decimal? Pendiente { get; set; }
    public decimal? PorcEjecutado { get; set; }
}