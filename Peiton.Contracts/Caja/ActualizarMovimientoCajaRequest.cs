namespace Peiton.Contracts.Caja;


public class ActualizarMovimientoCajaRequest
{
    public bool Anticipo { get; set; }
    public int? Recepcion { get; set; }
    public string? RecepcionOtro { get; set; }
    public int? ParentescoId { get; set; }
}
