namespace Peiton.Core.Entities
{
    public class LugarResidencia
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public bool CondicionesCentro { get; set; }
		public bool CondicionesDomicilio { get; set; }
		public string? TextoInformeSocial { get; set; }

		/* public virtual ICollection<DatosSociales> DatosSociales { get; } = new List<DatosSociales>(); */

	}
}