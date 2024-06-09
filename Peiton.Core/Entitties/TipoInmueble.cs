namespace Peiton.Core.Entities
{
    public class TipoInmueble
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;

		/* public virtual ICollection<Inmueble> Inmuebles { get; } = new List<Inmueble>(); */

	}
}