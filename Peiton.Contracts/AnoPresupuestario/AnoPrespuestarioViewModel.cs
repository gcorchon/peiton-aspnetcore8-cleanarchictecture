namespace Peiton.Contracts.AnoPresupuestario;

public class AnoPresupuestarioViewModel
{
    public int Ano { get; set; }
    public string Descripcion { get; set; } = null!;
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public DateTime? FechaBaja { get; set; }
    public decimal SaldoInicialCaja { get; set; }
    public decimal SaldoInicialBanco { get; set; }
}

