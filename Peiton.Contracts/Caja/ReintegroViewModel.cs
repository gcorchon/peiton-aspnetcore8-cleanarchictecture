namespace Peiton.Contracts.Caja;

public class TuteladoReintegro
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = "";
    public IEnumerable<Cuenta> Cuentas { get; set; } = [];
}

public class Cuenta
{
    public int Id { get; set; }
    public string Iban { get; set; } = "";
    public decimal Saldo { get; set; }
    public DateTime FechaSaldo { get; set; }
}

public class TuteladoReintegroSerializado
{
    public TuteladoReintegro Tutelado { get; set; } = null!;
    public int Cuenta { get; set; }
    public decimal Importe { get; set; }
}
