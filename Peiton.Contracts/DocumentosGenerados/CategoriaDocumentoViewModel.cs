namespace Peiton.Contracts.DocumentosGenerados;

public class CategoriaDocumentoViewModel
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public string CssClass { get; set; } = null!;
    public IEnumerable<DocumentoListItem> Documentos { get; set; } = null!;
}