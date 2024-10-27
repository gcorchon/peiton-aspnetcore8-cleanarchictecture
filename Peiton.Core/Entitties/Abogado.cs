namespace Peiton.Core.Entities;
public class Abogado
{
	public int Id { get; set; }
	public string Nombre { get; set; } = null!;
	public string Login { get; set; } = null!;
	public bool Senalamientos { get; set; }
	public string? NumeroColegiado { get; set; }

	/* public virtual ICollection<OtroAsunto> OtrosAsuntos { get; } = new List<OtroAsunto>(); */
	/* public virtual ICollection<PuntoInformacion> PuntosInformaciones { get; } = new List<PuntoInformacion>(); */

	public virtual ICollection<Senalamiento> SenalamientosAsignado { get; } = new List<Senalamiento>();
	public virtual ICollection<Senalamiento> SenalamientosAsistente { get; } = new List<Senalamiento>();
	/* public virtual ICollection<Tutelado> Tutelados { get; } = new List<Tutelado>(); */
	/* public virtual ICollection<Urgencia> Urgencias { get; } = new List<Urgencia>(); */

}
