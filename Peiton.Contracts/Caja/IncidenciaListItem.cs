namespace Peiton.Contracts.Caja;

public class IncidenciaListItem
{
    public int Id { get; set; }
    public DateTime FechaPago { get; set; }
    public string Nombre { get; set; } = "";
    public string Concepto { get; set; } = "";
    public decimal Importe { get; set; }
    public string RazonIncidencia { get; set; } = "";
}