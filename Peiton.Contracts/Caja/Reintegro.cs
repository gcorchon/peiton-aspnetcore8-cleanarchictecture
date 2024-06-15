namespace Peiton.Contracts.Caja;
public class Reintegro
{
    public string ApellidosNombre { get; set; } = "";
    public decimal SaldoCaja { get; set; }
    public string Concepto { get; set; } = "";
    public decimal Importe { get; set; }
    public DateTime FechaPago { get; set; }
    public bool Anticipo { get; set; }
}