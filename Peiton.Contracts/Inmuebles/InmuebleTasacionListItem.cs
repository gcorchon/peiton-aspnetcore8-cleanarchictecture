namespace Peiton.Contracts.Inmuebles;
public class InmuebleTasacionListItem
{
    public int Id { get; set; }
    public string Tutelado { get; set; } = null!;
    public string DireccionCompleta { get; set; } = null!;
    public string TipoTasacion { get; set; } = null!;
    public string Trabajador { get; set; } = null!;
    public string Estado { get; set; } = null!;
}
