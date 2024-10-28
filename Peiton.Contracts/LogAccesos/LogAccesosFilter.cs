namespace Peiton.Contracts.LogAccesos;

public class LogAccesosFilter
{
    public string? Usuario { get; set; } = null!;
    public DateTime? Fecha { get; set; }
    public string? IP { get; set; }
}