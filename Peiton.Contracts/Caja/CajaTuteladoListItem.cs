namespace Peiton.Contracts.Caja;

public class CajaTuteladoListItem : CajaPendienteTuteladoListItem
{
    public DateTime? FechaPago { get; set; }
    public bool Anticipo { get; set; }
    public decimal Balance { get; set; }
}