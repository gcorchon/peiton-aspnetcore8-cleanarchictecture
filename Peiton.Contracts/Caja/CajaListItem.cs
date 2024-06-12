namespace Peiton.Contracts.Caja;

public class CajaListItem
{
    public int Id { get; set; }
    public DateTime FechaAutorizacion { get; set; }
    public DateTime? FechaPago { get; set; }
    public string Nombre { get; set; } = "";
    public string Concepto { get; set; } = "";
    public string Tipo { get; set; } = "";
    public decimal Importe { get; set; }
    public string Estado { get; set; } = "";
    public bool TuteladoMuerto { get; set; }
}