namespace Peiton.Core.Entities
{
    public class TareaAgenda
	{
		public int TuteladoId { get; set; }
		public int Orden { get; set; }
		public string Descripcion { get; set; } = null!;
		public bool Completado { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}