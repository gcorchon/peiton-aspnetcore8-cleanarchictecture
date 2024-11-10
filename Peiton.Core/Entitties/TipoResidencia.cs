using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TipoResidencia
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<DatosSociales> DatosSocialesTipoCentroDeDia { get; } = new List<DatosSociales>(); */
	/* public virtual ICollection<DatosSociales> DatosSocialesTipoResidencia { get; } = new List<DatosSociales>(); */

}
