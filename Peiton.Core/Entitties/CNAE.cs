namespace Peiton.Core.Entities;
public class CNAE
{
	public string Cnae2009 { get; set; } = null!;
	public string Description { get; set; } = null!;

	public int? CategoriaId { get; set; }
	public virtual Categoria? Categoria { get; set; }
	public virtual ICollection<Company> Companies { get; } = new List<Company>();

}
