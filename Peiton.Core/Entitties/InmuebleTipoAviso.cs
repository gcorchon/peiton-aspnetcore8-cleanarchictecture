namespace Peiton.Core.Entities
{
    public class InmuebleTipoAviso
	{
		public int InmuebleAvisoId { get; set; }
		public int Orden { get; set; }
		public int TipoAvisoId { get; set; }
		public decimal? Importe { get; set; }
		public virtual InmuebleAviso InmuebleAviso { get; set; }= null!;
		public virtual TipoAviso TipoAviso { get; set; }= null!;

	}
}