using System.Collections;
using System.Text.Json.Serialization;
using Peiton.Contracts.Common;

namespace Peiton.Contracts.Tablas;

public class TypeScriptTableDefinition
{
    public string ColumnName { get; set; } = null!;
    public string TypeScriptType { get; set; } = null!;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxLength { get; set; }
    public bool IsPrimaryKey { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public bool IsComputed { get; set; }


    public bool IsReadOnly => this.IsPrimaryKey || this.IsComputed;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ForeignKeyReferencedTable { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<ListItem>? Items { get; set; }
}