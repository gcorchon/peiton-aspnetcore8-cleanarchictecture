namespace Peiton.Core.Entities
{
    public class Categoria
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public int TipoCategoriaId { get; set; }
		public int? CategoriaPadreId { get; set; }
		public bool Visible { get; set; }
		public virtual Categoria? CategoriaPadre { get; set; }
		public virtual TipoCategoria TipoCategoria { get; set; }= null!;
		/* public virtual ICollection<AccountTransaction> AccountsTransactions { get; } = new List<AccountTransaction>(); */
		/* public virtual ICollection<Categoria> Categorias { get; } = new List<Categoria>(); */
		/* public virtual ICollection<Regla> Reglas { get; } = new List<Regla>(); */
		public virtual ICollection<CNAE> CNAE { get; } = new List<CNAE>();
	}
}