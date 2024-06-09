namespace Peiton.Core.Entities
{
    public class TipoPrestamo
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;

		/* public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>(); */

	}
}