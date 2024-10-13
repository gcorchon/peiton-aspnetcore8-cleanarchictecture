namespace Peiton.Core.Entities;
public class VehiculoEntidad
{
	public int Id { get; set; }
	public string Nombre { get; set; } = null!;
	public string Matricula { get; set; } = null!;
	public string Marca { get; set; } = null!;
	public string Modelo { get; set; } = null!;
	public string Color { get; set; } = null!;
	public string Combustible { get; set; } = null!;

	/* public virtual ICollection<VehiculoEntidadReserva> VehiculosEntidadesReservas { get; } = new List<VehiculoEntidadReserva>(); */

}
