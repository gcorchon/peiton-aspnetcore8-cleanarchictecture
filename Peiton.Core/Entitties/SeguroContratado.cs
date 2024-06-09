namespace Peiton.Core.Entities
{
    public class SeguroContratado
	{
		public int TuteladoId { get; set; }
		public int Orden { get; set; }
		public int? TipoSeguroId { get; set; }
		public int? SeguroId { get; set; }
		public string? NumeroPoliza { get; set; }
		public DateTime? Fecha { get; set; }
		public string? Observaciones { get; set; }
		public bool Baja { get; set; }
		public int? InmuebleId { get; set; }
		public virtual Inmueble? Inmueble { get; set; }
		public virtual Seguro? Seguro { get; set; }
		public virtual TipoSeguro? TipoSeguro { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}