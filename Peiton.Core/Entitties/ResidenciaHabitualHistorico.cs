namespace Peiton.Core.Entities;
public class ResidenciaHabitualHistorico
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public string Tipo { get; set; } = null!;
	public int? CentroId { get; set; }
	public DateTime? FechaIngreso { get; set; }
	public int? TipoCentroId { get; set; }
	public int? TipoFinanciacionId { get; set; }
	public int? TipoFinanciacionPublicaId { get; set; }
	public bool? AnticiposResidencia { get; set; }
	public bool? EstanciaTemporal { get; set; }
	public int? TipoViaId { get; set; }
	public string? Direccion { get; set; }
	public string? Numero { get; set; }
	public string? Portal { get; set; }
	public string? Escalera { get; set; }
	public string? Piso { get; set; }
	public string? Puerta { get; set; }
	public string? CodigoPostal { get; set; }
	public string? Municipio { get; set; }
	public int? ProvinciaId { get; set; }
	public string? Telefono1 { get; set; }
	public string? Telefono2 { get; set; }
	public int? DistritoId { get; set; }
	public DateTime Fecha { get; set; }
	public bool? ChequeServicio { get; set; }
	public bool? PagoAMTA { get; set; }
	public bool? PagaTutelado { get; set; }
	public bool? PagaFamiliar { get; set; }
	public string? Observaciones { get; set; }
	public virtual Centro? Centro { get; set; }
	public virtual Distrito? Distrito { get; set; }
	public virtual Provincia? Provincia { get; set; }
	public virtual TipoCentro? TipoCentro { get; set; }
	public virtual TipoFinanciacionPublica? TipoFinanciacionPublica { get; set; }
	public virtual TipoVia? TipoVia { get; set; }

}
