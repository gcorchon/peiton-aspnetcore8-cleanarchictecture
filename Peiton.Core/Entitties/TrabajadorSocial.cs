namespace Peiton.Core.Entities
{
    public class TrabajadorSocial
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;
		public string Clave { get; set; } = null!;

		/* public virtual ICollection<PuntoInformacion> PuntosInformaciones { get; } = new List<PuntoInformacion>(); */
		/* public virtual ICollection<Tutelado> Tutelados { get; } = new List<Tutelado>(); */
		/* public virtual ICollection<Urgencia> Urgencias { get; } = new List<Urgencia>(); */

	}
}