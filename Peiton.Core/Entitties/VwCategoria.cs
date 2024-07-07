namespace Peiton.Core.Entities;

public class VwCategoria
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public int? VwCategoriaPadreId { get; set; }
    public int Level { get; set; }
    public string BreadCrumb { get; set; } = null!;
    public int TipoCategoriaId { get; set; }
    public virtual VwCategoria VwCategoriaPadre { get; set; } = null!;
    public virtual TipoCategoria TipoCategoria { get; set; } = null!;
    public virtual ICollection<VwCategoria> VwCategorias { get; } = new List<VwCategoria>();
}