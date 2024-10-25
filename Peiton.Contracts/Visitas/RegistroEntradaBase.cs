namespace Peiton.Contracts.Visitas;

public class RegistroEntradaBase
{
    public Visitado[] Visitadas { get; set; } = [];
    public DateTime Fecha { get; set; }
    public string HoraEntrada { get; set; } = null!;
    public string? HoraSalida { get; set; }
    public string? Observaciones { get; set; }
    public int MotivoEntradaId { get; set; }
}