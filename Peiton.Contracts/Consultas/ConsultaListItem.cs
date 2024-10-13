namespace Peiton.Contracts.Consultas;

public class ConsultaListItem
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = "";
    public string? Resumen { get; set; }
    public string Categoria { get; set; } = "";
    public string? Usuarios { get; set; }
}
