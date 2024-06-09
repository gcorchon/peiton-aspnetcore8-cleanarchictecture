namespace Peiton.Core.Entities
{
    public class OtroAsunto
	{
		public int TuteladoId { get; set; }
		public int Orden { get; set; }
		public int? OtroAsuntoTipoId { get; set; }
		public int? TipoAbogado { get; set; }
		public int? AbogadoExternoId { get; set; }
		public int? AbogadoInternoId { get; set; }
		public bool? Terminado { get; set; }
		public virtual Abogado? AbogadoInterno { get; set; }
		public virtual AbogadoExterno? AbogadoExterno { get; set; }
		public virtual OtroAsuntoTipo? OtroAsuntoTipo { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}