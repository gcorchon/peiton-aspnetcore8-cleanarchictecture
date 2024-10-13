namespace Peiton.Core.Entities;
public class EquipoAtencionEntidadGestora
{
	public int EntidadGestoraId { get; set; }
	public int Orden { get; set; }
	public int? CategoriaProfesionalEntidadGestoraId { get; set; }
	public string? Otros { get; set; }
	public int? TipologiaProfesionalEntidadGestoraId { get; set; }
	public int? Total { get; set; }
	public float? Horas { get; set; }
	public virtual CategoriaProfesionalEntidadGestora? CategoriaProfesionalEntidadGestora { get; set; }
	public virtual EntidadGestora EntidadGestora { get; set; } = null!;
	public virtual TipologiaProfesionalEntidadGestora? TipologiaProfesionalEntidadGestora { get; set; }

}
