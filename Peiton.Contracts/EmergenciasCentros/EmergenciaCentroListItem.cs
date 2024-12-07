namespace Peiton.Contracts.EmergenciasCentros;

public class EmergenciaCentroListItem
{
    public int Id { get; set; }
	public string MotivoEmergenciaCentro { get; set; } = null!;
	public DateTime Fecha { get; set; }
	public string Descripcion { get; set; } = null!;
    public bool TieneListaComprobacion { get; set; }
}