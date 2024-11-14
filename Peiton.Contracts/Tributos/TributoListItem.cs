namespace Peiton.Contracts.Tributos;

public class TributoListItem
{
    public int Id { get; set; }
    public string Tributo { get; set; } = null!;
    public DateTime FechaPresentacion { get; set; }
    public string Objeto { get; set; } = null!;
    public bool Domiciliado { get; set; }
    public decimal? Importe { get; set; }
}