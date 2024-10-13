namespace Peiton.Core.Entities;
public class ApoyoFormal
{
	public int TuteladoId { get; set; }
	public int Orden { get; set; }
	public int? TipoServicioApoyoFormalId { get; set; }
	public int? ServicioApoyoFormalId { get; set; }
	public int? AtencionApoyoFormalId { get; set; }
	public int? EducadorSocialId { get; set; }
	public string? Frecuencia { get; set; }
	public string? Coste { get; set; }
	public int? RelacionAMTAVisitaId { get; set; }
	public int? RelacionAMTAContactoId { get; set; }
	public int? CentroId { get; set; }
	public DateTime? FechaIngreso { get; set; }
	public int? TipoCentroDiaId { get; set; }
	public int? TipoFinanciacionId { get; set; }
	public virtual AtencionApoyoFormal? AtencionApoyoFormal { get; set; }
	public virtual EducadorSocial? EducadorSocial { get; set; }
	public virtual RelacionAMTAContacto? RelacionAMTAContacto { get; set; }
	public virtual RelacionAMTAVisita? RelacionAMTAVisita { get; set; }
	public virtual ServicioApoyoFormal? ServicioApoyoFormal { get; set; }
	public virtual TipoServicioApoyoFormal? TipoServicioApoyoFormal { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;
	public virtual Centro? Centro { get; set; }
	public virtual TipoCentroDia? TipoCentroDia { get; set; }
	public virtual TipoFinanciacion? TipoFinanciacion { get; set; }

}
