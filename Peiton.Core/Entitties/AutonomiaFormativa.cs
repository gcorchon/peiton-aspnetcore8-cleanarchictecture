using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class AutonomiaFormativa
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<DatosSociales> DatosSocialesFormativaAutonomiaFormativa { get; } = new List<DatosSociales>(); */
	/* public virtual ICollection<DatosSociales> DatosSocialesLaboralAutonomiaFormativa { get; } = new List<DatosSociales>(); */
	/* public virtual ICollection<DatosSociales> DatosSocialesOcioAutonomiaFormativa { get; } = new List<DatosSociales>(); */

}
