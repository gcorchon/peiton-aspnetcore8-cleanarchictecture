namespace Peiton.Core.Entities
{
    public class InmuebleMotivoAutorizacion
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public int InmuebleTipoAutorizacionId { get; set; }
		public virtual InmuebleTipoAutorizacion InmuebleTipoAutorizacion { get; set; }= null!;
		/* public virtual ICollection<InmuebleAutorizacion> InmueblesAutorizaciones { get; } = new List<InmuebleAutorizacion>(); */

	}
}