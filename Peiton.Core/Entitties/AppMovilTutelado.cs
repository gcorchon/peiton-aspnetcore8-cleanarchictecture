namespace Peiton.Core.Entities
{
    public class AppMovilTutelado
	{
		public int TuteladoId { get; set; }
		public string NumeroTelefono { get; set; } = null!;
		public bool Activado { get; set; }
		public string? CodigoValidacion { get; set; }
		public string? OneSignalId { get; set; }
		public bool SolicitarRecompensas { get; set; }
		public bool InformacionComercial { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}