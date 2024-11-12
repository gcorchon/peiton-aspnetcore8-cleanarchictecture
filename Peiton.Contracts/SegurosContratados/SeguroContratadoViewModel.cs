using Peiton.Contracts.Common;

namespace Peiton.Contracts.SegurosContratados;

public class SeguroContratadoViewModel
{

    public int Orden { get; set; }
    public int? TipoSeguroId { get; set; }
    public int? SeguroId { get; set; }
    public string? NumeroPoliza { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Observaciones { get; set; }
    public bool Baja { get; set; }
    public ListItem? Inmueble { get; set; }
}