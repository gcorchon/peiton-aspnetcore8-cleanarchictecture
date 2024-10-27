namespace Peiton.Contracts.Comunicaciones;

public class Whasapeiton
{
    public IEnumerable<int>? UserIds { get; set; }
    public IEnumerable<int>? GroupIds { get; set; }

    public IEnumerable<int>? UserCcIds { get; set; }
    public IEnumerable<int>? GroupCcIds { get; set; }

    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
    public string? CssClass { get; set; }
}