namespace Peiton.Contracts.Archivos;

public class ArchivoListItem
{
    public int CategoriaArchivoId { get; set; }
    public string Categoria { get; set; } = null!;
    public string CssClass { get; set; } = null!;
    public int ArchivoId { get; set; }
    public string Descripcion { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public string Tags { get; set; } = null!;
    public DateTime Fecha { get; set; }
}