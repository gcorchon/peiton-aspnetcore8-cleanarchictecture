namespace Peiton.Contracts.Tributos;

public class TributoViewModel
{
    public int TributoId { get; set; }
    public DateTime FechaPresentacion { get; set; }
    public int? TributoPeriodicidadId { get; set; }
    public string Objeto { get; set; } = null!;
    public string? Observaciones { get; set; }
    public bool Domiciliado { get; set; }
    public int? TributoEstadoId { get; set; }
    public int? TributoSubestadoId { get; set; }
    public bool Baja { get; set; }
    public int? Ano { get; set; }
    public int? Periodo { get; set; }
    public decimal? Importe { get; set; }
    public string? Matricula { get; set; }
}