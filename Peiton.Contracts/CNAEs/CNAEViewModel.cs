using Peiton.Contracts.Common;

namespace Peiton.Contracts.CNAEs;

public class CNAEViewModel
{
    public string Cnae2009 { get; set; } = null!;
    public string Description { get; set; } = null!;

    public ListItem? Categoria { get; set; }
}

