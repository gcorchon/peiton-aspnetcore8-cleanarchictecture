namespace Peiton.Core.Entities
{
    public class Diagnostico
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public string? TextoInformeSocial { get; set; }
		public int? DiagnosticoId { get; set; }

		/* public virtual ICollection<TuteladoDiagnostico> TuteladosDiagnosticos { get; } = new List<TuteladoDiagnostico>(); */

	}
}