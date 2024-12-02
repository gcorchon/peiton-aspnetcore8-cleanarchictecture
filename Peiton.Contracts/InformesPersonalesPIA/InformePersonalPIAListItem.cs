namespace Peiton.Contracts.InformesPersonalesPIA;

public class InformePersonalPIAListItem
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string IP { get; set; } = null!;
    public string Usuario { get; set; } = null!;
}