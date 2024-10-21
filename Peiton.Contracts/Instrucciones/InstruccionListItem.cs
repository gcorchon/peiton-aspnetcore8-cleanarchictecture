namespace Peiton.Contracts.Instrucciones;

public class InstruccionListItem
{
    public int CategoriaInstruccionId { get; set; }
    public string Categoria { get; set; } = null!;
    public string CssClass { get; set; } = null!;
    public int InstruccionId { get; set; }
    public string Descripcion { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public DateTime Fecha { get; set; }
}