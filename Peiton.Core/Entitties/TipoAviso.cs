namespace Peiton.Core.Entities;
public class TipoAviso
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public decimal Importe { get; set; }

	/* public virtual ICollection<InmuebleTipoAviso> InmueblesTiposAvisos { get; } = new List<InmuebleTipoAviso>(); */

}
