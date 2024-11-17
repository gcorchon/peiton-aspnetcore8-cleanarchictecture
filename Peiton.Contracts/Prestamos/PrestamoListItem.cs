namespace Peiton.Contracts.Prestamos;

public class PrestamoListItem
{
    public int Id { get; set; }
    public bool Manual { get; set; }
    public string? TipoPrestamo { get; set; }
    public string? EntidadFinanciera { get; set; }
    public decimal? Inicial { get; set; }
    public decimal? Pendiente { get; set; }
    public DateTime? FechaSaldo { get; set; }
    public DateTime? FechaBaja { get; set; }
    public bool Baja { get; set; }
    public string? Porcentaje { get; set; }
}