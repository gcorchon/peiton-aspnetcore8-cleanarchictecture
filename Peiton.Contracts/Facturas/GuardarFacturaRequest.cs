namespace Peiton.Contracts.Facturas;

public class GuardarFacturaRequest
{
	public string? NumRegAMTA { get; set; }
	public string? CodFactura { get; set; }
	public DateTime? FechaRegistro { get; set; }
	public int? EstadoInicial { get; set; }
	public DateTime? FechaFactura { get; set; }
	public string? NIFExpedidor { get; set; }
	public string? Denominacion { get; set; }
	public string? NumeroFactura { get; set; }
	public string? CodDirAMTA { get; set; }
	public int? EstadoContable { get; set; }
	public DateTime? FechaEstadoContable { get; set; }
	public DateTime? FechaInicioComputoPago { get; set; }
	public decimal? Importe { get; set; }
	public bool Domiciliado { get; set; }
	public bool FACe { get; set; }
	public string? Ejercicio { get; set; }
	public string? NumeroRegistroFACe { get; set; }
}
