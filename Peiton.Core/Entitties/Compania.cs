namespace Peiton.Core.Entities
{
    public class Compania
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public bool MostrarCajaTexto { get; set; }

		/* public virtual ICollection<TuteladoCompania> TuteladosCompanias { get; } = new List<TuteladoCompania>(); */

	}
}