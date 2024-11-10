using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TipoCGJ
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<ControlCuentaGeneral> ControlesCuentasGenerales { get; } = new List<ControlCuentaGeneral>(); */

}
