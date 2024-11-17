using Peiton.Contracts.Common;

namespace Peiton.Contracts.EfectosPublicos;

public class EfectoPublicoListItem : EfectoPublicoBase
{
    public int Id { get; set; }
    public ListItem EntidadFinanciera { get; set; } = null!;
}