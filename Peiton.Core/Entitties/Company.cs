namespace Peiton.Core.Entities
{
    public class Company
	{
		public int Id { get; set; }
		public string CIF { get; set; } = null!;
		public string RZS { get; set; } = null!;
		public string Cnae2009 { get; set; } = null!;
		public string CodSchober { get; set; } = null!;
		public virtual CNAE Cnae2009Navigation { get; set; }= null!;
		public virtual Schober CodSchoberNavigation { get; set; }= null!;

	}
}