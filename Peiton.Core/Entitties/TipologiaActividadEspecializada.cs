using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TipologiaActividadEspecializada
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<ActividadEspecializada> ActividadesEspecializadas { get; } = new List<ActividadEspecializada>(); */

}
