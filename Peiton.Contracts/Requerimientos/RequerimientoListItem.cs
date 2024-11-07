namespace Peiton.Contracts.Requerimientos;

public class RequerimientoListItem
{
    public int Id { get; set; }
    public string Tutelado { get; set; } = null!;
    public string? Tipo { get; set; }
    public string? Detalle { get; set; }
    public string Contestado { get; set; } = null!;
}