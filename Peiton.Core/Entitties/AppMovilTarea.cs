namespace Peiton.Core.Entities
{
    public class AppMovilTarea
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public int TipoObjetivoId { get; set; }
		public int ObjetivoSocialId { get; set; }
		public int AppMovilTipoTareaId { get; set; }
		public int? AppMovilPeriodicidadId { get; set; }
		public int? AppMovilCumplimientoId { get; set; }
		public DateTime Fecha { get; set; }
		public DateTime? FechaBaja { get; set; }
		public virtual AppMovilCumplimiento? AppMovilCumplimiento { get; set; }
		public virtual AppMovilPeriodicidad? AppMovilPeriodicidad { get; set; }
		public virtual AppMovilTipoTarea AppMovilTipoTarea { get; set; }= null!;
		public virtual ObjetivoSocial ObjetivoSocial { get; set; }= null!;
		public virtual TipoObjetivo TipoObjetivo { get; set; }= null!;
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}