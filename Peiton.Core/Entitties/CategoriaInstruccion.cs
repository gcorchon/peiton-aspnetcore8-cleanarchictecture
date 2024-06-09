namespace Peiton.Core.Entities
{
    public class CategoriaInstruccion
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public int? CategoriaInstruccionId { get; set; }
		public string? CssClass { get; set; }
		public virtual CategoriaInstruccion? CategoriaInstruccionPadre { get; set; }
		/* public virtual ICollection<CategoriaInstruccion> CategoriasInstrucciones { get; } = new List<CategoriaInstruccion>(); */
		/* public virtual ICollection<Instruccion> Instrucciones { get; } = new List<Instruccion>(); */

	}
}