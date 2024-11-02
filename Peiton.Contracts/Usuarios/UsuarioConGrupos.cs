using Peiton.Contracts.Common;

namespace Peiton.Contracts.Usuarios;

public class UsuarioConGrupos
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = null!;
    public IEnumerable<ListItem> Grupos { get; set; } = null!;
}