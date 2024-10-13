namespace Peiton.Core.Entities;
public class Capitulo
{
	public int Id { get; set; }
	public string Tipo { get; set; } = null!;
	public string Numero { get; set; } = null!;
	public string Descripcion { get; set; } = null!;
	public int Ano { get; set; }
	/*public virtual AnoPresupuestario AnoNavigation { get; set; }= null!;*/
	public virtual ICollection<Partida> Partidas { get; } = new List<Partida>();

}
