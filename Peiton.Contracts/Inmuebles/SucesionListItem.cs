namespace Peiton.Contracts.Inmuebles
{
    public class SucesionListItem
    {
        public int Id { get; set; }
        public string Tutelado { get; set; } = null!;
        public string Origen { get; set; } = null!;
        public string TipoSucesion { get; set; } = null!;
        public string Trabajador { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }
}
