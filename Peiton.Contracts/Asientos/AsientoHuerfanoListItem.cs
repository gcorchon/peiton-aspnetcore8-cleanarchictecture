namespace Peiton.Contracts.Asientos;

public class AsientoHuerfanoListItem
{
    public int Id { get; set; }
    public string Capitulo { get; set; } = "";
    public string Partida { get; set; } = "";
    public int Numero { get; set; }
    public string Concepto { get; set; } = "";
    public decimal Importe { get; set; }
    public DateTime FechaAutorizacion { get; set; }
}

