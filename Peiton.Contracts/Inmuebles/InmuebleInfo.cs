namespace Peiton.Contracts.Inmuebles;

public class InmuebleInfo
{
    public string DireccionCompleta { get; set; } = null!;
    public string? Llave { get; set; }

    public TuteladoAvisoInmueble Tutelado { get; set; } = null!;
}