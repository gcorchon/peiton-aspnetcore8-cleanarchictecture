namespace Peiton.Contracts.Archivos;

public class ArchivoListItem
{
    public int Id { get; set; }
    public string Subcategoria { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public string? Tags { get; set; }
    public bool TuAppoyo { get; set; }
    public DateTime Fecha { get; set; }
}