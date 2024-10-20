namespace Peiton.Contracts.VehiculosEntidad;

public class GuardarReservaRequest
{
    public DateTime Fecha { get; set; }
    public Reserva[] Reservas { get; set; } = [];
}
