namespace Peiton.Core.Entities
{
    public class TuteladoSaludPsiquica
	{
		public int TuteladoId { get; set; }
		public int Orden { get; set; }
		public int? SituacionSaludId { get; set; }
		public int? ConcienciaEnfermedadId { get; set; }
		public int? AdhesionTratamientoId { get; set; }
		public bool? SeguimientoTratamiento { get; set; }
		public int? AutonomiaTratamientoId { get; set; }
		public string? Patologia { get; set; }
		public virtual AdhesionTratamiento? AdhesionTratamiento { get; set; }
		public virtual AutonomiaTratamiento? AutonomiaTratamiento { get; set; }
		public virtual ConcienciaEnfermedad? ConcienciaEnfermedad { get; set; }
		public virtual SituacionSalud? SituacionSalud { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}