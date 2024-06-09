namespace Peiton.Core.Entities
{
    public class AppMovilEstadoAnimo
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public string Icono { get; set; } = null!;

		/* public virtual ICollection<AppMovilRegistroDiario> AppMovilRegistrosDiarios { get; } = new List<AppMovilRegistroDiario>(); */

	}
}