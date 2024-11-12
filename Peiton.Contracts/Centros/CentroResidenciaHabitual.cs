namespace Peiton.Contracts.Centros;

public class CentroResidenciaHabitual
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string DireccionCompleta { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? Fax { get; set; }
    public string? Observaciones { get; set; }
}