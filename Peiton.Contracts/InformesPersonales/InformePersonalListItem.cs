namespace Peiton.Contracts.InformesPersonales;

public class InformePersonalListItem
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string IP { get; set; } = null!;
    public string Usuario { get; set; } = null!;
}