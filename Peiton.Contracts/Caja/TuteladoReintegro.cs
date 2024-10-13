namespace Peiton.Contracts.Caja;

public class TuteladoReintegro
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = "";
    public IEnumerable<Cuenta> Cuentas { get; set; } = [];
}