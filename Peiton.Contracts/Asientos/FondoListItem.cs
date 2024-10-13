namespace Peiton.Contracts.Asientos;

public class FondoListItem
{
    public int Id { get; set; }
    public string Tutelado { get; set; } = "";
    public string Dni { get; set; } = "";
    public decimal Ingresos { get; set; }
    public decimal Gastos { get; set; }
    public decimal Diferencia { get; set; }
}

