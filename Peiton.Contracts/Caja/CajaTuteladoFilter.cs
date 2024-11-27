namespace Peiton.Contracts.Caja;

public class CajaTuteladoFilter : CajaPendienteTuteladoFilter
{
    public DateTime? FechaPago { get; set; }
    public bool? Anticipo { get; set; }
    public decimal? Balance { get; set; }

}