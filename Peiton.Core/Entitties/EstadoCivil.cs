namespace Peiton.Core.Entities;
public class EstadoCivil
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public string? DescripcionFemenino { get; set; }

	/* public virtual ICollection<Tutelado> Tutelados { get; } = new List<Tutelado>(); */

}
