namespace Peiton.Core.Entities;
public class Permiso
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public string JsName { get; set; } = null!;
	public int? PermisoId { get; set; }
	public bool Visible { get; set; }

	/* public virtual ICollection<Grupo> Grupos { get; } = new List<Grupo>(); */
	/* public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>(); */
}
