namespace Peiton.Contracts.Grupos;

public class GuardarGrupoRequest
{
    public string Descripcion { get; set; } = null!;
    public IEnumerable<int> Permisos { get; set; } = null!;

    public IEnumerable<int> Usuarios { get; set; } = null!;
}