namespace Peiton.Contracts.Caja;

public class CajaAMTAListItem
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Concepto { get; set; } = "";
    public string PersonaReceptora { get; set; } = "";
    public decimal Importe { get; set; }
    public decimal Saldo { get; set; }
    public int? CajaId { get; set; }
}