using Peiton.Contracts.Common;

namespace Peiton.Contracts.Grupos;

public class GrupoConUsuaios : GrupoViewModel
{
    public IEnumerable<ListItem> Usuarios { get; set; } = null!;
}