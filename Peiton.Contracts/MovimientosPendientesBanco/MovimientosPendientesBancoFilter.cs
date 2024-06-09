namespace Peiton.Contracts.MovimientosPendientesBanco
{
    public class MovimientosPendientesBancoFilter
    {
        public bool? Pendientes { get; set; }
        public int? Cuenta { get; set; }
        public string? Description { get; set; }
        public string? Reference { get; set; }
        public string? Payer { get; set; }
        public string? Payee { get; set; }
        public string? Quantity { get; set; }
        public string? OperationDate { get; set; }
    }
}
