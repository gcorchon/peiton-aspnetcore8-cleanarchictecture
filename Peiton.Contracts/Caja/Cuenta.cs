namespace Peiton.Contracts.Caja;

public class Cuenta
{
    public int Id { get; set; }
    public string Iban { get; set; } = "";
    public decimal Saldo { get; set; }
    public DateTime FechaSaldo { get; set; }
}