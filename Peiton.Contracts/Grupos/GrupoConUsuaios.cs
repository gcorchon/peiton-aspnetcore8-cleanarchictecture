using Peiton.Contracts.Common;

namespace Peiton.Contracts.Grupos;

public class GrupoConUsuaios : GrupoListItem
{
    public IEnumerable<ListItem> Usuarios { get; set; } = null!;
}