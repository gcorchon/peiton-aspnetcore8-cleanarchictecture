namespace Peiton.Contracts.Loans;

public class LoanRendicionViewModel
{
    public int Id { get; set; }
    public string Numero { get; set; } = null!;
    public string EntidadFinanciera { get; set; } = null!;
    public decimal? Inicial { get; set; }
    public decimal? Pendiente { get; set; }
    public string Porcentaje { get; set; } = null!;
    public DateTime Fecha { get; set; }
}