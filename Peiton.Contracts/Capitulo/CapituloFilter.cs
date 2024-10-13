namespace Peiton.Contracts.Capitulo;

public class CapituloFilter
{
    public int Ano { get; set; } = 0;
    public string? Tipo { get; set; }
    public string? Capitulo { get; set; }
    public string? Partida { get; set; }
    public string? Descripcion { get; set; }
    public string? SaldoInicial { get; set; }
}