namespace Peiton.Contracts.Inmuebles;
public class CrearSucesionRequest
{
    public int TuteladoId { get; set; }
    public int SucesionTipoId { get; set; }
    public DateTime? FechaEscritura { get; set; }
    public string Origen { get; set; } = null!;
}
