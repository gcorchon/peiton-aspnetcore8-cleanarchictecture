namespace Peiton.Contracts.Account;

public class JustificacionIngresosYGastos
{
    public string Categoria { get; set; } = null!;
    public int TipoCategoriaId { get; set; }
    public int CategoriaId { get; set; }
    public decimal Total { get; set; }
}