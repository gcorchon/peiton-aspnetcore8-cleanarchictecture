namespace Peiton.Contracts.Tutelados;

public class TuteladoListItem
{
    public int Id { get; set; }
    public string NumeroExpediente { get; set; } = null!;
    public string NombreCompleto { get; set; } = null!;
    public string DNI { get; set; } = null!;
    public string Cargo { get; set; } = null!;
    public bool Muerto { get; set; }
}