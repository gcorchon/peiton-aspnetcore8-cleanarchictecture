namespace Peiton.Contracts.Salas;

public class GuardarReservasRequest
{
    public DateTime Fecha { get; set; }
    public Reserva[] Reservas { get; set; } = null!;
}