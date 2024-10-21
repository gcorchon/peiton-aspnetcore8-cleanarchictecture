namespace Peiton.Contracts.Instrucciones;

public class CategoriaInstruccionViewModel
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public string CssClass { get; set; } = null!;
    public IEnumerable<InstruccionViewModel> Instrucciones { get; set; } = null!;
}