namespace Peiton.Contracts.Inmuebles
{
    public class InmuebleAutorizacionesFilter
    {
        public string? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Tipo { get; set; }
        public string? Trabajador { get; set; }

        public bool Pendiente { get; set; }
        public bool Presentado { get; set; }
        public bool Autorizado { get; set; }
        public bool Firme { get; set; }
        public bool? Archivo { get; set; }
    }
}
