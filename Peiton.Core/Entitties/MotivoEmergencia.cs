namespace Peiton.Core.Entities
{
    public class MotivoEmergencia
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;

		/* public virtual ICollection<Emergencia> Emergencias { get; } = new List<Emergencia>(); */

	}
}