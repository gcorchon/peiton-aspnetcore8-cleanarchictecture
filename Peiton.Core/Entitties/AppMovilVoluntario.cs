using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class AppMovilVoluntario
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<AppMovilTuteladoRecompensa> AppMovilTuteladosRecompensas { get; } = new List<AppMovilTuteladoRecompensa>(); */

}
