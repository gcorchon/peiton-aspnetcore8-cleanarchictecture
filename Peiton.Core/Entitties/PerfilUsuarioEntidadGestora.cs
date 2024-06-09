namespace Peiton.Core.Entities
{
    public class PerfilUsuarioEntidadGestora
	{
		public int EntidadGestoraId { get; set; }
		public int Orden { get; set; }
		public string? TipoDiscapacidad { get; set; }
		public string? Edad { get; set; }
		public string? NumeroPersonas { get; set; }
		public virtual EntidadGestora EntidadGestora { get; set; }= null!;

	}
}