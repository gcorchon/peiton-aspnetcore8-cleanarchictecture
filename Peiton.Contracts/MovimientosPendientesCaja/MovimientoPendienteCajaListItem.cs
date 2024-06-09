namespace Peiton.Contracts.MovimientosPendientesCaja
{
    public class MovimientoPendienteCajaListItem
    {
        public int Id { get; set; } //CajaAMTAId
        public string Concepto { get; set; } = string.Empty;
        public string Persona { get; set; } = string.Empty;
        public decimal Importe { get; set; }    
        public DateTime Fecha { get; set; }
    }
}
