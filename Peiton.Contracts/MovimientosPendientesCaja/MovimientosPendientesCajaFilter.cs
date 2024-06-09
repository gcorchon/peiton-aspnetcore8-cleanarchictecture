namespace Peiton.Contracts.MovimientosPendientesCaja
{
    public class MovimientosPendientesCajaFilter
    {
        public bool? Pendientes { get; set; }
        public string? Concepto { get; set; }
        public string? Persona { get; set; }
        public string? Importe { get; set; }
        public string? Fecha { get; set; }       
    }
}
