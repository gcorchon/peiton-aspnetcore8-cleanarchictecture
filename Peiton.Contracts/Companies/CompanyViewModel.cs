namespace Peiton.Contracts.Companies
{
    public class CompanyViewModel
    {
        public string CIF { get; set; } = null!;
        public string RZS { get; set; } = null!;
        public string? Categoria { get; set; }
        public string Cnae2009 { get; set; } = null!;
        public string DescripcionCnae2009 { get; set; } = null!;
    }
}
