using Peiton.Contracts.Common;

namespace Peiton.Contracts.ProcedimientosAdicionales;

public class ProcedimientoAdicionalViewModel
{
    public int Orden { get; set; }
    public ListItem Juzgado { get; set; } = null!;
    public int ProcedimientoId { get; set; }
    public string NumeroProcedimiento { get; set; } = null!;
    public int? AbogadoExternoId { get; set; }
    public int? AbogadoInternoId { get; set; }
    public int? TipoAbogado { get; set; }
    public bool Terminado { get; set; }
    public int? OrdenJurisdiccionalId { get; set; }
    public string? Observaciones { get; set; }
    public DateTime? FechaInicioInterno { get; set; }
}