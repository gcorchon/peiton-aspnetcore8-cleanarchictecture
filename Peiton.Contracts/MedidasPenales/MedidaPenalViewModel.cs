using Peiton.Contracts.Common;

namespace Peiton.Contracts.MedidasPenales;

public class MedidaPenalViewModel
{
    public int Orden { get; set; }
    public ListItem Juzgado { get; set; } = null!;
    public string? NumeroProcedimiento { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public int? MedidaPenalTipoId { get; set; }
    public int? MedidaPenalNaturalezaId { get; set; }
    public int? MedidaPenalMedidaId { get; set; }
    public string? Observaciones { get; set; }
    public bool Terminado { get; set; }
    public bool Suspendida { get; set; }
}