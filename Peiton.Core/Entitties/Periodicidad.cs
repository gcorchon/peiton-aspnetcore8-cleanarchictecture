namespace Peiton.Core.Entities
{
    public class Periodicidad
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public int? Periodo { get; set; }
		public string? Unidad { get; set; }

		/* public virtual ICollection<Caja> Caja { get; } = new List<Caja>(); */
		/* public virtual ICollection<CajaIncidencia> CajaIncidencias { get; } = new List<CajaIncidencia>(); */

	}
}