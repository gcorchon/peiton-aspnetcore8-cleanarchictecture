namespace Peiton.Contracts.Salas;

public class ReservaViewModel
{
    public int SalaId { get; set; }
    public string Intervalo { get; set; } = null!;
    public bool Propia { get; set; }
    public string Usuario { get; set; } = null!;
}