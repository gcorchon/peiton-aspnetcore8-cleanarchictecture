using Peiton.Contracts.Common;

namespace Peiton.Contracts.ApoyosFormales;

public class ApoyoFormalViewModel
{
    public int Orden { get; set; }
    public int? TipoServicioApoyoFormalId { get; set; }
    public int? ServicioApoyoFormalId { get; set; }
    public int? AtencionApoyoFormalId { get; set; }
    public int? EducadorSocialId { get; set; }
    public string? Frecuencia { get; set; }
    public string? Coste { get; set; }
    public int? RelacionAMTAVisitaId { get; set; }
    public int? RelacionAMTAContactoId { get; set; }
    public ListItem? Centro { get; set; }
    public DateTime? FechaIngreso { get; set; }
    public int? TipoCentroDiaId { get; set; }
    public int? TipoFinanciacionId { get; set; }
}