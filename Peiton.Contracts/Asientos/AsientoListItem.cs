namespace Peiton.Contracts.Asientos;

public class AsientoListItem
{
    public int Id { get; set; }
    public string Capitulo { get; set; } = "";
    public string Partida { get; set; } = "";
    public int Numero { get; set; }
    public string Tipo { get; set; } = "";
    public string IngresoGasto { get; set; } = "";
    public string Concepto { get; set; } = "";
    public decimal Importe { get; set; }
    public DateTime? FechaPago { get; set; }
    public DateTime? FechaAutorizacion { get; set; }

}

