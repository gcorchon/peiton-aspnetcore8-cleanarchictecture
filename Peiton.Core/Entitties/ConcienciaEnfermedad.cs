using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class ConcienciaEnfermedad
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<TuteladoSaludFisica> TuteladosSaludFisicas { get; } = new List<TuteladoSaludFisica>(); */
	/* public virtual ICollection<TuteladoSaludPsiquica> TuteladosSaludPsiquicas { get; } = new List<TuteladoSaludPsiquica>(); */

}
