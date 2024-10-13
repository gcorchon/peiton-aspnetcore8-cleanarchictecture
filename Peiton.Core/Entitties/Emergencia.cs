namespace Peiton.Core.Entities;
public class Emergencia
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public int UsuarioId { get; set; }
	public int MotivoEmergenciaId { get; set; }
	public DateTime Fecha { get; set; }
	public string Descripcion { get; set; } = null!;
	public int? EmergenciaLlamadaId { get; set; }
	public string? CheckList { get; set; }
	public virtual Usuario Usuario { get; set; } = null!;
	public virtual EmergenciaLlamada? EmergenciaLlamada { get; set; }
	public virtual MotivoEmergencia MotivoEmergencia { get; set; } = null!;
	public virtual Tutelado Tutelado { get; set; } = null!;

}
