namespace Peiton.Contracts.Visitas;

public class Visitante
{
    public string Dni { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public bool Tutelado { get; set; }
}