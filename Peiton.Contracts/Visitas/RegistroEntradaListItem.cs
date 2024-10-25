namespace Peiton.Contracts.Visitas;

public class RegistroEntradaListItem
{
    public int Id { get; set; }
    public string Visitante { get; set; } = null!;
    public string Visitado { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public string HoraEntrada { get; set; } = null!;
    public string? HoraSalida { get; set; }
}