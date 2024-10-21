namespace Peiton.Contracts.Procesos;

public class CategoriaProcesoViewModel
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public string CssClass { get; set; } = null!;
    public IEnumerable<ProcesoViewModel> Procesos { get; set; } = null!;
}