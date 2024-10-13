namespace Peiton.Contracts.Capitulo;

public class CapituloViewModel
{
    public int CapituloId { get; set; }
    public int? PartidaId { get; set; }
    public string Tipo { get; set; } = null!;
    public string Capitulo { get; set; } = null!;
    public string? Partida { get; set; }
    public string Descripcion { get; set; } = null!;
    public decimal? SaldoInicial { get; set; }
}

