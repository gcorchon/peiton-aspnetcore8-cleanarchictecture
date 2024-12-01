namespace Peiton.Contracts.Caja;


public class CrearMovimientoCajaTuteladoRequest : ActualizarMovimientoCajaTuteladoRequest
{
    public int TuteladoId { get; set; }
    public int Tipo { get; set; }
}