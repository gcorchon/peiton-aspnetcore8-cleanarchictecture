namespace Peiton.Core.Entities;
public class PuntoInformacion
{
	public int Id { get; set; }
	public DateTime Fecha { get; set; }
	public int? AbogadoId { get; set; }
	public int? TrabajadorSocialId { get; set; }
	public string? Solicitante { get; set; }
	public string? DNI { get; set; }
	public string? Telefono { get; set; }
	public string? Email { get; set; }
	public bool? Atencion { get; set; }
	public int? PuntoInformacionTipoConsultaId { get; set; }
	public string? Observaciones { get; set; }
	public virtual Abogado? Abogado { get; set; }
	public virtual PuntoInformacionTipoConsulta? PuntoInformacionTipoConsulta { get; set; }
	public virtual TrabajadorSocial? TrabajadorSocial { get; set; }

}
