using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class Ocupacion
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<InmuebleAviso> InmueblesAvisos { get; } = new List<InmuebleAviso>(); */
	/* public virtual ICollection<InmuebleSolicitudAlquilerVenta> InmueblesSolicitudesAlquileresVentas { get; } = new List<InmuebleSolicitudAlquilerVenta>(); */

}
