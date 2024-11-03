namespace Peiton.Contracts.Grupos;

public class GrupoViewModel : GrupoConUsuaios
{
    public IEnumerable<int> Permisos { get; set; } = null!;
}
