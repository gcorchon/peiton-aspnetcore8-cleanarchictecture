namespace Peiton.Core.Entities
{
    public class InmuebleAnejo
	{
		public int InmuebleId { get; set; }
		public int Orden { get; set; }
		public int TipoAnejoId { get; set; }
		public string? Detalle { get; set; }
		public virtual Inmueble Inmueble { get; set; }= null!;
		public virtual TipoAnejo TipoAnejo { get; set; }= null!;

	}
}