using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TipoRelacionConvivencional
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<TuteladoRelacionConvivencional> TuteladosRelacionesConvivencionales { get; } = new List<TuteladoRelacionConvivencional>(); */

}
