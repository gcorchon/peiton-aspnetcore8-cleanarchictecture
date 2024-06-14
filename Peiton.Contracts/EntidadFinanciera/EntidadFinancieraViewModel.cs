using Peiton.Contracts.Account;

namespace Peiton.Contracts.EntidadFinanciera;

public class EntidadFinancieraViewModel
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = "";
    public string? CssClass { get; set; }
    public IEnumerable<AccountViewModel> Accounts { get; set; } = new List<AccountViewModel>();
}