namespace Peiton.Core.Entities;
public class Rule
{
	public int Id { get; set; }
	public string Description { get; set; } = null!;
	public string FormData { get; set; } = null!;
	public int SortOrder { get; set; }

	/* public virtual ICollection<AccountTransaction> AccountsTransactions { get; } = new List<AccountTransaction>(); */

}
