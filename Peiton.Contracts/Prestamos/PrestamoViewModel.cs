namespace Peiton.Contracts.Prestamos;

public class PrestamoViewModel
{
    public int? TipoPrestamoId { get; set; }
    public int EntidadFinancieraId { get; set; }
    public decimal? Inicial { get; set; }
    public decimal? Pendiente { get; set; }
    public DateTime? FechaSaldo { get; set; }
    public string? Porcentaje { get; set; }
    public DateTime? FechaInicio { get; set; }
    public string? Observaciones { get; set; }
    public bool? Baja { get; set; }
    public DateTime? FechaBaja { get; set; }
    public string? Numero { get; set; }
}