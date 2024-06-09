namespace Peiton.Core.Entities
{
    public class TuteladoDiagnostico
	{
		public int TuteladoId { get; set; }
		public int DiagnosticoId { get; set; }
		public bool Principal { get; set; }
		public virtual Diagnostico Diagnostico { get; set; }= null!;
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}