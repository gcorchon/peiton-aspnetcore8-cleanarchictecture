namespace Peiton.Contracts.Documentos;

public class DocumentoListItem
{
    public int Id { get; set; }
    public string Subcategoria { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public string? Tags { get; set; }
    public DateTime Fecha { get; set; }
}