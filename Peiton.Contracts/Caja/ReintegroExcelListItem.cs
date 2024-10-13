namespace Peiton.Contracts.Caja;

public class ReintegroExcelListItem
{
    public string NombreCompleto { get; set; } = "";
    public string? Numero { get; set; } = "";
    public decimal? Saldo { get; set; }
    public decimal? Importe { get; set; }
}

