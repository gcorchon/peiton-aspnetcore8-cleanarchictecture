using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class MotivoEmergenciaCentro
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<EmergenciaCentro> EmergenciasCentros { get; } = new List<EmergenciaCentro>(); */

}
