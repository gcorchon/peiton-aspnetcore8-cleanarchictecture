namespace Peiton.Core.Entities;
public class VehiculoEntidadReserva
{
	public int VehiculoEntidadId { get; set; }
	public DateTime Fecha { get; set; }
	public string Intervalo { get; set; } = null!;
	public int UsuarioId { get; set; }
	public virtual Usuario Usuario { get; set; } = null!;
	public virtual VehiculoEntidad VehiculoEntidad { get; set; } = null!;

}
