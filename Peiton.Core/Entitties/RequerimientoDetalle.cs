using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class RequerimientoDetalle
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
}
