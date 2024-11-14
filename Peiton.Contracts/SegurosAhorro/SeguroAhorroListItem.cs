using Peiton.Contracts.Common;

namespace Peiton.Contracts.SegurosAhorro;

public class SeguroAhorroListItem : SeguroAhorroBase
{
    public int Id { get; set; }
    public ListItem Seguro { get; set; } = null!;
}