namespace Peiton.Core.Entities;
public class InmuebleTipoTitularidad
{
	public int InmuebleId { get; set; }
	public int Orden { get; set; }
	public int TipoTitularidadId { get; set; }
	public string Porcentaje { get; set; } = null!;
	public virtual Inmueble Inmueble { get; set; } = null!;
	public virtual TipoTitularidad TipoTitularidad { get; set; } = null!;

}
