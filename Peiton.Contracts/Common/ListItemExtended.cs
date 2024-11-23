using System.Text.Json.Serialization;

namespace Peiton.Contracts.Common;

public class ListItemExtended : ListItem
{

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ParentId { get; set; }
}