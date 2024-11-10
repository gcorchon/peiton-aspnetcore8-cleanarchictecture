using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class RelacionApoyoInformal
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<ApoyoInformal> ApoyosInformales { get; } = new List<ApoyoInformal>(); */

}
