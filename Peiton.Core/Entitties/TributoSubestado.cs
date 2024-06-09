namespace Peiton.Core.Entities
{
    public class TributoSubestado
	{
		public int Id { get; set; }
		public int TributoEstadoId { get; set; }
		public string Descripcion { get; set; } = null!;
		public virtual TributoEstado TributoEstado { get; set; }= null!;
		/* public virtual ICollection<TributoTutelado> TributosTutelados { get; } = new List<TributoTutelado>(); */

	}
}