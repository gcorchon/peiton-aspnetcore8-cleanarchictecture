namespace Peiton.Core.Entities
{
    public class Agente
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public string? Nombre { get; set; }
		public string? CIF { get; set; }
		public string? Domicilio { get; set; }
		public string? Telefono { get; set; }
		public string? email { get; set; }

		/* public virtual ICollection<Inmueble> InmueblesAgenteDeshaucio { get; } = new List<Inmueble>(); */
		/* public virtual ICollection<Inmueble> InmueblesAgenteVenta { get; } = new List<Inmueble>(); */
		/* public virtual ICollection<Inmueble> InmueblesAgenteHerencia { get; } = new List<Inmueble>(); */
		/* public virtual ICollection<Inmueble> InmueblesAgentePendienteValoracion { get; } = new List<Inmueble>(); */
		/* public virtual ICollection<Inmueble> InmueblesAgenteProcesoRegularizacion { get; } = new List<Inmueble>(); */

	}
}