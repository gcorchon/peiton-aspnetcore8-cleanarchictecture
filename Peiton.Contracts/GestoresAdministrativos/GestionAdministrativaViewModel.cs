using Peiton.Contracts.Common;

namespace Peiton.Contracts.GestoresAdministrativos
{
    public class GestionAdministrativaViewModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TuteladoId { get; set; }
        public int GestionAdministrativaTipoId { get; set; }
        public string? Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public ListItem? GestorAdministrativo { get; set; }
        public bool Solicitada { get; set; }
        public bool Designada { get; set; }
        public bool Finalizada { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public DateTime? FechaDesignacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public decimal? Importe { get; set; }
    }
}