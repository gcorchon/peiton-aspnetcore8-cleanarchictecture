using Peiton.Contracts.Common;

namespace Peiton.Contracts.AccountTransactions;

public class EntidadExtractoViewModel
{
    public string Descripcion { get; set; } = null!;
    public string? CssClass { get; set; }
    public IEnumerable<ListItem> Accounts { get; set; } = [];
}