namespace Peiton.Core.Entities
{
    public class InformePersonal
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public DateTime Fecha { get; set; }
		public int UsuarioId { get; set; }
		public byte[] Informe { get; set; }
		public string IP { get; set; } = null!;
		public virtual Tutelado Tutelado { get; set; }= null!;
		public virtual Usuario Usuario { get; set; }= null!;

	}
}