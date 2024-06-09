namespace Peiton.Core.Entities
{
    public class Felicitacion
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public string Imagen { get; set; } = null!;

		/* public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>(); */
	}
}