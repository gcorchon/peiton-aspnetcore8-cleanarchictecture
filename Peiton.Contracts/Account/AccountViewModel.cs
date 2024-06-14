namespace Peiton.Contracts.Account;

public class AccountViewModel
{
    public int Id { get; set; }
    public string? WebAlias { get; set; } = "";
    public string? Iban { get; set; } = "";
    public decimal? Saldo { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime? FechaSaldo { get; set; }
}