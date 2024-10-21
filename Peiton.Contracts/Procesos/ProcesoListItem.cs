namespace Peiton.Contracts.Procesos;

public class ProcesoListItem
{
    public int CategoriaProcesoId { get; set; }
    public string Categoria { get; set; } = null!;
    public string CssClass { get; set; } = null!;
    public int ProcesoId { get; set; }
    public string Descripcion { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public DateTime Fecha { get; set; }
}