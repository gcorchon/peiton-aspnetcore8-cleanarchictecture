namespace Peiton.Contracts.Citas;

public class CitaListItem
{
    public int Id {get; set;}
    public string Descripcion { get; set; } = null!;
    public DateTime Fecha { get; set; }
}