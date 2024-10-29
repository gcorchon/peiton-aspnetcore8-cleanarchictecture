namespace Peiton.Core.Entities;
public class Sucursal
{
	public int Id { get; set; }
	public int EntidadFinancieraId { get; set; }
	public string Numero { get; set; } = null!;
	public string CodigoPostal { get; set; } = null!;
	public string Direccion { get; set; } = null!;
	public string Ciudad { get; set; } = null!;
	public string Provincia { get; set; } = null!;
	public string? Telefono { get; set; }
	public virtual EntidadFinanciera EntidadFinanciera { get; set; } = null!;

}
