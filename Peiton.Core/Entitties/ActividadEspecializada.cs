namespace Peiton.Core.Entities
{
    public class ActividadEspecializada
	{
		public int EntidadGestoraId { get; set; }
		public int Orden { get; set; }
		public string TipoActividad { get; set; } = null!;
		public int? TipologiaActividadEspecializadaId { get; set; }
		public string? NumeroHorasSemanales { get; set; }
		public string? Ubicacion { get; set; }
		public virtual EntidadGestora EntidadGestora { get; set; }= null!;
		public virtual TipologiaActividadEspecializada? TipologiaActividadEspecializada { get; set; }

	}
}