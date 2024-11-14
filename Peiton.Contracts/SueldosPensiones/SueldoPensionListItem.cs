using Peiton.Contracts.Common;

namespace Peiton.Contracts.SueldosPensiones;

public class SueldoPensionListItem : SueldoPensionBase
{
    public int Id { get; set; }
    public ListItem TipoPension { get; set; } = null!;
}