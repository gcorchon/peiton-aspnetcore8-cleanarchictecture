namespace Peiton.Contracts.Inmuebles
{
    public class InmuebleAvisoListItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string DireccionCompleta { get; set; } = null!;
        public string TipoAviso { get; set; } = null!;
        public string Trabajador { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }
}
