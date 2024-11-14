namespace Peiton.Contracts.Inmuebles;

public class InmuebleListItem
{
    public int Id { get; set; }
    public string DireccionCompleta { get; set; } = null!;
    public string TipoInmueble { get; set; } = null!;
}