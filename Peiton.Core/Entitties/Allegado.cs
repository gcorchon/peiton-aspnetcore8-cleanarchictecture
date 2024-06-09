namespace Peiton.Core.Entities
{
    public class Allegado
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public bool MostrarCajaTexto { get; set; }

		/* public virtual ICollection<TuteladoAllegado> TuteladosAllegados { get; } = new List<TuteladoAllegado>(); */

	}
}