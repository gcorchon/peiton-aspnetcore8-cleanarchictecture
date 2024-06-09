namespace Peiton.Core.Entities
{
    public class TributoEstado
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public int Orden { get; set; }

		/* public virtual ICollection<TributoSubestado> TributosSubestados { get; } = new List<TributoSubestado>(); */
		/* public virtual ICollection<TributoTutelado> TributosTutelados { get; } = new List<TributoTutelado>(); */

	}
}