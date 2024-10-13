namespace Peiton.Core.Entities;
public class AppMovilRecompensa
{
	public int Id { get; set; }
	public string Titulo { get; set; } = null!;
	public string Descripcion { get; set; } = null!;
	public string Imagen { get; set; } = null!;
	public bool Visible { get; set; }
	public int Dias { get; set; }

	/* public virtual ICollection<AppMovilTuteladoRecompensa> AppMovilTuteladosRecompensas { get; } = new List<AppMovilTuteladoRecompensa>(); */

}
