namespace Peiton.Core.Entities
{
    public class Actividad
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public bool MostrarDesplegable { get; set; }

		/* public virtual ICollection<TuteladoActividad> TuteladosActividades { get; } = new List<TuteladoActividad>(); */

	}
}