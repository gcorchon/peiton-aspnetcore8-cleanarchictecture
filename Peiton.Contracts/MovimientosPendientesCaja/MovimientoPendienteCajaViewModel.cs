using Peiton.Contracts.Asientos;

namespace Peiton.Contracts.MovimientosPendientesCaja;
public class MovimientoPendienteCajaViewModel
{
    public int Id { get; set; } //CajaAMTA Id             
    public DateTime Fecha { get; set; }
    public decimal Importe { get; set; }
    public IEnumerable<AsientoViewModel> Asientos { get; set; } = null!;
}
