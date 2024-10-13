namespace Peiton.Core.Entities;
public class LogCredencial
{
	public string EurobitsId { get; set; } = null!;
	public string UserId { get; set; } = null!;
	public DateTime Fecha { get; set; }
	public int? CredencialId { get; set; }
	public string Productos { get; set; } = null!;

}
