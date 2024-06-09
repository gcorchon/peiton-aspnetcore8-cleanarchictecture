namespace Peiton.Core.Entities
{
    public class Proceso
	{
		public int Id { get; set; }
		public int CategoriaProcesoId { get; set; }
		public string Descripcion { get; set; } = null!;
		public string? ContentType { get; set; }
		public string FileName { get; set; } = null!;
		public DateTime Fecha { get; set; }
		public virtual CategoriaProceso CategoriaProceso { get; set; }= null!;

	}
}