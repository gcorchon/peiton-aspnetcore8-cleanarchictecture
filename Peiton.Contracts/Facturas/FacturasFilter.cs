namespace Peiton.Contracts.Facturas
{
    public class FacturasFilter
    {
        public string? FechaRegistro { get; set; }
        public int? EstadoInicial { get; set; }
        public int? EstadoContable { get; set; }
        public string? Denominacion { get; set; }
        public string? NumeroFactura { get; set; }
        public string? Importe { get; set; }
        public string? FechaPago { get; set; }
        public bool? Asiento { get; set; }
    }
}
