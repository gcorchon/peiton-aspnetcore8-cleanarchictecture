namespace Peiton.Core.Entities
{
    public class AppMovilActividad
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public string Icono { get; set; } = null!;
		public bool Visible { get; set; }

	}
}