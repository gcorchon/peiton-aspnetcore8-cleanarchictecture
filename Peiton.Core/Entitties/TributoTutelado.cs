namespace Peiton.Core.Entities
{
    public class TributoTutelado
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public int TributoId { get; set; }
		public DateTime FechaPresentacion { get; set; }
		public int? TributoPeriodicidadId { get; set; }
		public string Objeto { get; set; } = null!;
		public string? Observaciones { get; set; }
		public bool Domiciliado { get; set; }
		public int? TributoEstadoId { get; set; }
		public int? TributoSubestadoId { get; set; }
		public bool Baja { get; set; }
		public int? Ano { get; set; }
		public int? Periodo { get; set; }
		public decimal? Importe { get; set; }
		public string? Matricula { get; set; }
		public virtual Tributo Tributo { get; set; }= null!;
		public virtual TributoEstado? TributoEstado { get; set; }
		public virtual TributoPeriodicidad? TributoPeriodicidad { get; set; }
		public virtual TributoSubestado? TributoSubestado { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}