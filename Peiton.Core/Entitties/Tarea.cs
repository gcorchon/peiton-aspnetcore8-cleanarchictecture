namespace Peiton.Core.Entities
{
    public class Tarea
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public int? TareaDepartamentoId { get; set; }
		public int? TareaCategoriaId { get; set; }
		public int? TareaSubcategoriaId { get; set; }
		public int? TareaTipoId { get; set; }
		public int? UsuarioDistribuidorId { get; set; }
		public int UsuarioSolicitanteId { get; set; }
		public int? UsuarioGestorId { get; set; }
		public int? TareaEstadoId { get; set; }
		public int? TareaEntidadId { get; set; }
		public string? Motivo { get; set; }
		public string? ComentariosDistribuidor { get; set; }
		public string? ComentariosGestor { get; set; }
		public DateTime Fecha { get; set; }
		public DateTime? FechaGestion { get; set; }
		public DateTime? FechaCierre { get; set; }
		public string? Archivos { get; set; }
		public string? AlertasEnviadas { get; set; }
		public virtual TareaCategoria? TareaCategoria { get; set; }
		public virtual TareaDepartamento? TareaDepartamento { get; set; }
		public virtual TareaEstado? TareaEstado { get; set; }
		public virtual TareaSubcategoria? TareaSubcategoria { get; set; }
		public virtual TareaTipo? TareaTipo { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;
		public virtual Usuario? UsuarioGestor { get; set; }
		public virtual Usuario? UsuarioDistribuidor { get; set; }
		public virtual Usuario UsuarioSolicitante { get; set; }= null!;

	}
}