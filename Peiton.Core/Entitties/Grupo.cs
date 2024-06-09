namespace Peiton.Core.Entities
{
    public class Grupo
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;

		/* public virtual ICollection<ConsultaAlmacenada> ConsultasAlmacenadas { get; } = new List<ConsultaAlmacenada>(); */
		/* public virtual ICollection<Evento> Eventos { get; } = new List<Evento>(); */
		/* public virtual ICollection<Permiso> Permisos { get; } = new List<Permiso>(); */
		/* public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>(); */
	}
}