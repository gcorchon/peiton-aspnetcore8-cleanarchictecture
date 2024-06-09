namespace Peiton.Core.Entities
{
    public class EmergenciaCentro
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public int UsuarioId { get; set; }
		public int MotivoEmergenciaCentroId { get; set; }
		public DateTime Fecha { get; set; }
		public string Descripcion { get; set; } = null!;
		public string? CheckList { get; set; }
		public virtual Usuario Usuario { get; set; }= null!;
		public virtual MotivoEmergenciaCentro MotivoEmergenciaCentro { get; set; }= null!;
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}