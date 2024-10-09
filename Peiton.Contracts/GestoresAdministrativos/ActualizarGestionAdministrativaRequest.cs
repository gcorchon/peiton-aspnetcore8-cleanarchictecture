namespace Peiton.Contracts.GestoresAdministrativos
{
    public class ActualizarGestionAdministrativaRequest
    {
        public int Estado { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public DateTime? FechaDesignacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public int? GestorAdministrativoId { get; set; }
        public decimal? Importe { get; set; }
    }
}
