using Peiton.ListItems;

namespace Peiton.Core.Entities;
[ListItem]
public class PuntoInformacionTipoConsulta
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<PuntoInformacion> PuntosInformaciones { get; } = new List<PuntoInformacion>(); */

}
