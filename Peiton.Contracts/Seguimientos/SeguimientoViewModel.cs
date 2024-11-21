namespace Peiton.Contracts.Seguimientos;

public class SeguimientoViewModel : SeguimientoBase
{
    public Alerta[] AlertasEnviadas { get; set; } = null!;
}