namespace Peiton.Core.Entities;
public class AppMovilTipoTarea
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public int? ObjetivoSocialId { get; set; }
	public virtual ObjetivoSocial? ObjetivoSocial { get; set; }
	/* public virtual ICollection<AppMovilTarea> AppMovilTareas { get; } = new List<AppMovilTarea>(); */

}
