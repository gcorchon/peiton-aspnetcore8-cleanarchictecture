namespace Peiton.Contracts.Partida;
public class PartidaUpdateRequest
{
    public string Descripcion { get; set; } = null!;
    public decimal SaldoInicial { get; set; } = 0;
}
