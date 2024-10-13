namespace Peiton.Core.Entities;
public class TipoSeguro
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<SeguroContratado> SegurosContratados { get; } = new List<SeguroContratado>(); */

}
