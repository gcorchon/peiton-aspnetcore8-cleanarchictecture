namespace Peiton.Contracts.Requerimientos;

public class RequerimientosFilter
{
    public int? Id { get; set; }
    public string? Tutelado { get; set; }
    public int? TipoId { get; set; }
    public int? DetalleId { get; set; }
    public bool? Contestado { get; set; }
}