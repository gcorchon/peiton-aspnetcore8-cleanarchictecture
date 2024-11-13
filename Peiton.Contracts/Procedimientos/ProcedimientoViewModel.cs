namespace Peiton.Contracts.Procedimientos;

public class ProcedimientoViewModel
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public bool Normal { get; set; }
    public bool Adicional { get; set; }
    public int OrdenJurisdiccionalId { get; set; }
}