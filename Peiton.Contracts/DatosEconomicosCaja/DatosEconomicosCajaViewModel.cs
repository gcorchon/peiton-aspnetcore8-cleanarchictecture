namespace Peiton.Contracts.DatosEconomicosCaja;

public class DatosEconomicosCajaViewModel
{
    public int? LocalizacionCajaId { get; set; }
    public DateTime? FechaCustodia { get; set; }
    public bool? Tasado { get; set; }
    public bool? Entregado { get; set; }
    public DateTime? FechaEntregado { get; set; }
    public string? Descripcion { get; set; }
    public string? Observaciones { get; set; }
}