namespace Peiton.Contracts.VehiculosEntidad;

public class VehiculoEntidadReservaViewModel
{
    public int VehiculoEntidadId { get; set; }
    public DateTime Fecha{ get; set; }
    public bool Propia { get; set; }
    public string Usuario { get; set; } = null!;
}