namespace Peiton.Core.Entities;
public class LogAcceso
{
	public string Usuario { get; set; } = null!;
	public DateTime Fecha { get; set; }
	public string IP { get; set; } = null!;

}
