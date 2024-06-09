using Peiton.Contracts.Common;

namespace Peiton.Contracts.Asientos
{
    public class AsientoViewModel
    {
        public int Id { get; set; }
        public int? Numero { get; set; }
        public DateTime? FechaAutorizacion { get; set; }
        public DateTime? FechaPago { get; set; }
        public string? Concepto { get; set; }
        public int? TipoMovimiento { get; set; }
        public decimal? Importe { get; set; }
        public int? TipoPago { get; set; }
        public int? PartidaId { get; set; }
        public int? CapituloId { get; set; }
        public int? FormaPagoId { get; set; }
        public ListItem? Tutelado { get; set; }
        public ListItem? Cliente { get; set; }
        public IEnumerable<int> FacturaIds { get; set; } = new List<int>();
    }
    
    public class AsientoSaveRequest
    {
        public int? Id { get; set; }
        public int? Numero { get; set; }
        public DateTime? FechaAutorizacion { get; set; }
        public string? Concepto { get; set; }
        public int? TipoMovimiento { get; set; }
        public decimal? Importe { get; set; }
        public int? TipoPago { get; set; }
        public int? PartidaId { get; set; }
        public int? FormaPagoId { get; set; }
        public int? TuteladoId { get; set; }
        public int? ClienteId { get; set; }
        public IEnumerable<int> FacturaIds { get; set; } = new List<int>();

    }
}
