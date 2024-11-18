namespace Peiton.Contracts.Credenciales;

public class ActualizarCredencialRequest
{
    public int EntidadFinancieraId { get; set; }
    public bool DetenerRobot { get; set; }
    public Dictionary<string, string> Campos { get; set; } = null!;
}