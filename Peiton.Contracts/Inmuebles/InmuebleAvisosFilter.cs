namespace Peiton.Contracts.Inmuebles
{
    public class InmuebleAvisosFilter
    {
        public string? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Tipo { get; set; }
        public string? Trabajador { get; set; }

        public bool Pendiente { get; set; }
        public bool EnTramite { get; set; }
        public bool Finalizado { get; set; }
        public bool PendientePago { get; set; }
    }
}
