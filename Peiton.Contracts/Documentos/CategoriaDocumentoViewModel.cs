namespace Peiton.Contracts.Documentos;

public class CategoriaDocumentoViewModel
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public string CssClass { get; set; } = null!;
    public IEnumerable<DocumentoViewModel> Documentos { get; set; } = null!;
}