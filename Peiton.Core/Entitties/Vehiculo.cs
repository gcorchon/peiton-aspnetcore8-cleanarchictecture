namespace Peiton.Core.Entities;
public class Vehiculo
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public int TipoVehiculoId { get; set; }
	public string? Matricula { get; set; }
	public string? Observaciones { get; set; }
	public bool Baja { get; set; }
	public DateTime? FechaBaja { get; set; }
	public virtual TipoVehiculo TipoVehiculo { get; set; } = null!;
	public virtual Tutelado Tutelado { get; set; } = null!;

}
