using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class LeyNombramiento
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<DatosJuridicos> DatosJuridicos { get; } = new List<DatosJuridicos>(); */
	/* public virtual ICollection<DatosJuridicosHistorico> DatosJuridicosHistoricos { get; } = new List<DatosJuridicosHistorico>(); */

}
