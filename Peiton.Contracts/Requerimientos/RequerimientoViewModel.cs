using Peiton.Contracts.Common;

namespace Peiton.Contracts.Requerimientos;

public class RequerimientoViewModel
{
    public string? Comentarios { get; set; }
    public string? NumeroProcedimiento { get; set; }
    public DateTime FechaRequerimiento { get; set; }
    public DateTime? FechaContestado { get; set; }
    public bool Contestado { get; set; }
    public bool SolicitadoAplazamiento { get; set; }
    public int? RequerimientoTipoId { get; set; }
    public int? RequerimientoDetalleId { get; set; }
    public int? RequerimientoOrigenId { get; set; }
    public ListItem Tutelado { get; set; } = null!;
    public ListItem? Juzgado { get; set; }
    public ListItem? Usuario { get; set; }
    public int? ArchivoRequerimientoId { get; set; }
    public int? ContestacionRequerimientoId { get; set; }
}