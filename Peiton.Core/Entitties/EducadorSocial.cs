using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class EducadorSocial
{
	public int Id { get; set; }
	public string Nombre { get; set; } = null!;

	/* public virtual ICollection<ApoyoFormal> ApoyosFormales { get; } = new List<ApoyoFormal>(); */
	/* public virtual ICollection<Tutelado> Tutelados { get; } = new List<Tutelado>(); */

}
