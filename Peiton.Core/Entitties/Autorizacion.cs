namespace Peiton.Core.Entities
{
    public class Autorizacion
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public string Descripcion { get; set; } = null!;
		public bool? Aprobada { get; set; }
		public DateTime FechaSolicitud { get; set; }
		public int UsuarioId { get; set; }
		public DateTime? FechaAprobacion { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;
		public virtual Usuario Usuario { get; set; }= null!;

	}
}