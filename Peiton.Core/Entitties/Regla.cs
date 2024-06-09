namespace Peiton.Core.Entities
{
    public class Regla
	{
		public int Id { get; set; }
		public string Texto { get; set; } = null!;
		public int CategoriaId { get; set; }
		public virtual Categoria Categoria { get; set; }= null!;

	}
}