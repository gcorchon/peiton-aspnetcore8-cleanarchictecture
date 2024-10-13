namespace Peiton.Core.Entities;
public class Empresa
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public string? TipoDocumento { get; set; }
	public string? Documento { get; set; }
	public string? Cuenta { get; set; }
	public string? Observaciones { get; set; }

	/* public virtual ICollection<InmuebleAvisoCoste> InmueblesAvisosCostes { get; } = new List<InmuebleAvisoCoste>(); */

}
