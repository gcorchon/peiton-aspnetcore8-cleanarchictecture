namespace Peiton.Contracts.Emergencias;

public class EmergenciaListItem
{
    public int Id { get; set; }
	public string MotivoEmergencia { get; set; } = null!;
	public DateTime Fecha { get; set; }
	public string Descripcion { get; set; } = null!;
	public string? EmergenciaLlamada { get; set; }
    public bool TieneListaComprobacion { get; set; }
}