using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem("Nombre")]
public class AgenteArrendamiento
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public string? Nombre { get; set; }
	public string? CIF { get; set; }
	public string? Domicilio { get; set; }
	public string? Telefono { get; set; }
	public string? email { get; set; }

	/* public virtual ICollection<Arrendamiento> Arrendamientos { get; } = new List<Arrendamiento>(); */
	/* public virtual ICollection<Inmueble> Inmuebles { get; } = new List<Inmueble>(); */

}
