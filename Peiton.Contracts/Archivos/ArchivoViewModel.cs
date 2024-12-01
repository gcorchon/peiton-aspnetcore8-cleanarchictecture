namespace Peiton.Contracts.Archivos;

public class ArchivoViewModel
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public string? Tags { get; set; } = null!;
    public bool TuAppoyo { get; set; }
    public DateTime Fecha { get; set; }
}