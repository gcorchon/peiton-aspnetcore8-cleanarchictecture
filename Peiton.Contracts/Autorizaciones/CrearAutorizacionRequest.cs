namespace Peiton.Contracts.Autorizaciones;

public class CrearAutorizacionRequest : ActualizarAutorizacionRequest
{
    public int TuteladoId { get; set; }
}