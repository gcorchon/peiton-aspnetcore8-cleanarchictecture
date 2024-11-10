using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class CategoriaProfesionalEntidadGestora
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<EquipoAtencionEntidadGestora> EquiposAtencionesEntidadesGestoras { get; } = new List<EquipoAtencionEntidadGestora>(); */

}
