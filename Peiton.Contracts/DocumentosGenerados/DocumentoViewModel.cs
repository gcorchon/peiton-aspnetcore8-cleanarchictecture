namespace Peiton.Contracts.DocumentosGenerados;

public class DocumentoViewModel
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public string? Tags { get; set; } = null!;
    public DateTime Fecha { get; set; }
}