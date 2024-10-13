namespace Peiton.Core.Entities;
public class InformeMensual
{
	public DateTime Fecha { get; set; }
	public string CargosAsumidosDuranteMes { get; set; } = null!;
	public string CargosAtendidosDuranteMes { get; set; } = null!;
	public string CargosActivosACierreDeMes { get; set; } = null!;
	public string DistribucionPorSexo { get; set; } = null!;
	public string DatosDeDependencia { get; set; } = null!;
	public string LugarDeResidencia { get; set; } = null!;
	public string Inventario { get; set; } = null!;
	public string Seguimiento { get; set; } = null!;
	public string? Quejas { get; set; }

}
