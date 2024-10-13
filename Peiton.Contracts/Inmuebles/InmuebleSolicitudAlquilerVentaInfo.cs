namespace Peiton.Contracts.Inmuebles;

public class InmuebleSolicitudAlquilerVentaInfo
{
    public int Id { get; set; }
    public string DireccionCompleta { get; set; } = null!;
    public TuteladoSolicitudAlquilerVenta Tutelado { get; set; } = null!;
}

