namespace Peiton.Core.Entities
{
    public class TipoFinanciacion
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;

		/* public virtual ICollection<ApoyoFormal> ApoyosFormales { get; } = new List<ApoyoFormal>(); */

	}
}