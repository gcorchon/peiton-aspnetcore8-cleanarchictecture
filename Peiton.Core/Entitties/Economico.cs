namespace Peiton.Core.Entities
{
    public class Economico
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;
		public string Clave { get; set; } = null!;
		public string? Email { get; set; }

		/* public virtual ICollection<Tutelado> Tutelados { get; } = new List<Tutelado>(); */
		/* public virtual ICollection<Urgencia> Urgencias { get; } = new List<Urgencia>(); */

	}
}