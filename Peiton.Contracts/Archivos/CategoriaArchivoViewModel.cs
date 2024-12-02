namespace Peiton.Contracts.Archivos;

public class CategoriaArchivoViewModel
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public string CssClass { get; set; } = null!;
    public IEnumerable<ArchivoListItem> Archivos { get; set; } = null!;
}