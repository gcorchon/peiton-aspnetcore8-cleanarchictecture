namespace Peiton.Contracts.Caja;

public class TuteladoReintegroSerializado
{
    public TuteladoReintegro Tutelado { get; set; } = null!;
    public int Cuenta { get; set; }
    public decimal Importe { get; set; }
}
