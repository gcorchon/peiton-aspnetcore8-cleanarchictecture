namespace Peiton.Contracts.Citas;

public class ActualizarCitaRequest
{
    public string Descripcion { get; set; } = null!;
    public DateTime Fecha { get; set; }
}