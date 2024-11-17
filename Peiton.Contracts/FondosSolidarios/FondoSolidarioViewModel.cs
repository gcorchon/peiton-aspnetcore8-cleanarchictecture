namespace Peiton.Contracts.FondosSolidarios;

public class FondoSolidarioViewModel
{
    public int FondoSolidarioTipoFondoId { get; set; }
    public int FondoSolidarioPeriodicidadId { get; set; }
    public int FondoSolidarioDestinoId { get; set; }
    public decimal Importe { get; set; }
    public string ObservacionesSolicitud { get; set; } = null!;
    public bool FamiliaContribuye { get; set; }
    public DateTime? FechaCaducidad { get; set; }
    public bool Recuperable { get; set; }
}