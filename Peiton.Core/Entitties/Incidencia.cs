namespace Peiton.Core.Entities;
public class Incidencia
{
	public int Id { get; set; }
	public DateTime Fecha { get; set; }
	public int UsuarioId { get; set; }
	public string Titulo { get; set; } = null!;
	public string Descripcion { get; set; } = null!;
	public int IncidenciaEstadoId { get; set; }
	public DateTime? FechaCambioEstado { get; set; }
	public DateTime? FechaResolucion { get; set; }
	public virtual IncidenciaEstado IncidenciaEstado { get; set; } = null!;
	public virtual Usuario Usuario { get; set; } = null!;

}
