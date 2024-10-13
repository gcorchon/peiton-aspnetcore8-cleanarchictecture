namespace Peiton.Core.Entities;
public class AtencionApoyoFormal
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public int ServicioApoyoFormalId { get; set; }
	public virtual ServicioApoyoFormal ServicioApoyoFormal { get; set; } = null!;
	/* public virtual ICollection<ApoyoFormal> ApoyosFormales { get; } = new List<ApoyoFormal>(); */

}
