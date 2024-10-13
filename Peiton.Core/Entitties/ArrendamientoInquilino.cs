namespace Peiton.Core.Entities;
public class ArrendamientoInquilino
{
	public int ArrendamientoId { get; set; }
	public int Orden { get; set; }
	public string? Nombre { get; set; }
	public string? Contacto { get; set; }
	public string? Observaciones { get; set; }
	public string? DNI { get; set; }
	public virtual Arrendamiento Arrendamiento { get; set; } = null!;

}
