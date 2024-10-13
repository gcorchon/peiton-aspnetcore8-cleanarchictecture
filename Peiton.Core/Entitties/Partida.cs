namespace Peiton.Core.Entities;
public class Partida
{
	public int Id { get; set; }
	public int CapituloId { get; set; }
	public string Numero { get; set; } = null!;
	public string Descripcion { get; set; } = null!;
	public decimal SaldoInicial { get; set; }
	public virtual Capitulo Capitulo { get; set; } = null!;
	/* public virtual ICollection<Asiento> Asientos { get; } = new List<Asiento>(); */

}
