namespace Peiton.Contracts.Centros;

public class CentroListItem
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Poblacion { get; set; }
    public string? Provincia { get; set; }
    public string? CP { get; set; }
}