namespace Peiton.Contracts.FondosSolidarios;

public class FondoSolidarioListItem
{
    public int Id { get; set; }
    public string FondoSolidarioDestino { get; set; } = null!;
    public string Solicitante { get; set; } = null!;
    public decimal Importe { get; set; }
    public DateTime FechaSolicitud { get; set; }
    public DateTime? FechaCaducidad { get; set; }
    public DateTime? FechaBaja { get; set; }
    public string Estado { get; set; } = null!;

    public bool Caducado { get; set; }
    public bool Renovable { get; set; }
}