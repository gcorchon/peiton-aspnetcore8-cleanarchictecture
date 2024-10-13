namespace Peiton.Contracts.Inmuebles;
public class SucesionesFilter
{
    public string? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Origen { get; set; }
    public int? SucesionTipoId { get; set; }
    public string? Trabajador { get; set; }

    public bool Pendiente { get; set; }
    public bool Solicitada { get; set; }
    public bool Autorizada { get; set; }
    public bool Firme { get; set; }
}
