namespace Peiton.Contracts.SegurosAhorro;

public class SeguroAhorroBase
{
    public string? NumeroPoliza { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaRescate { get; set; }
    public DateTime? FechaBaja { get; set; }
    public bool Vitalicio { get; set; }
    public decimal? PrimaUnica { get; set; }
}