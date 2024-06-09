namespace Peiton.Contracts.Partida
{
    public class CreatePartidaRequest
    {
        public string Numero { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal SaldoInicial { get; set; }
    }
}
