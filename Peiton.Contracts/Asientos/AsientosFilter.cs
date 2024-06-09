namespace Peiton.Contracts.Asientos
{
    public class AsientosFilter
    {
        public DateTime? FechaPagoDesde { get; set; }
        public DateTime? FechaPagoHasta { get; set; }
        public DateTime? FechaAutorizacionDesde { get; set; }
        public DateTime? FechaAutorizacionHasta { get; set; }
        public int? TuteladoId { get; set; }
        public int? ClienteId { get; set; }
        public string? Capitulo { get; set; }
        public string? Partida { get; set; }
        public string? Numero { get; set;}
        public string? Tipo { get; set; }
        public string? IngresoGasto { get; set; }
        public string? Concepto { get; set; }
        public string? Importe { get; set; }
        public string? FechaPago { get; set; }
        public string? FechaAutorizacion { get; set; }
    }
}
