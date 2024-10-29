namespace Peiton.Contracts.Sucursales;
public class CrearSucursalRequest
{
    public int TuteladoId { get; set; }
    public int SucesionTipoId { get; set; }
    public DateTime? FechaEscritura { get; set; }
    public string Origen { get; set; } = null!;
}
