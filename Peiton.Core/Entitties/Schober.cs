namespace Peiton.Core.Entities;
public class Schober
{
	public string CodSchober { get; set; } = null!;
	public string Description { get; set; } = null!;

	public virtual ICollection<Company> Companies { get; } = new List<Company>();

}
