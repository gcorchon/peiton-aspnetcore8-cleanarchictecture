namespace Peiton.ListItems;

[AttributeUsage(AttributeTargets.Class)]
public class ListItemAttribute : Attribute
{
    public string? Text { get; init; }
    public string? Value { get; init; }
    public string? ParentValue { get; set; }

    public ListItemAttribute() { }
    public ListItemAttribute(string? text = null, string? value = null, string? parentValue = null)
    {
        this.Text = text;
        this.Value = value;
        this.ParentValue = parentValue;
    }
}