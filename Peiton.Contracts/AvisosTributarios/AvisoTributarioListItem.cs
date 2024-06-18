namespace Peiton.Contracts.AvisosTributarios
{
    public class AvisoTributarioListItem
    {
        public int Id { get; set; }
        public string Tutelado { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string TipoAvisoTributario { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }
}
