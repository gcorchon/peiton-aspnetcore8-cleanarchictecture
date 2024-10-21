namespace Peiton.Contracts.Documentos;

public class DocumentoListItem
{
    public int CategoriaDocumentoId { get; set; }
    public string Categoria { get; set; } = null!;
    public string CssClass { get; set; } = null!;
    public int DocumentoId { get; set; }
    public string Descripcion { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public string Tags { get; set; } = null!;
    public DateTime Fecha { get; set; }
}