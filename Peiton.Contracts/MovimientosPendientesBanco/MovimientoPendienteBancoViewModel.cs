using Peiton.Contracts.Asientos;

namespace Peiton.Contracts.MovimientosPendientesBanco
{
    public class MovimientoPendienteBancoViewModel
    {
        public int Id { get; set; } //AccountTransactionCP Id
        public string WebAlias { get; set; } = null!; //Cuenta
        public string Iban { get; set; } = null!; //Identificacion

        public DateTime OperationDate { get; set; } //FechaPago
        public decimal Quantity { get; set; } //ImporteMovimiento       

        public IEnumerable<AsientoViewModel> Asientos { get; set; } = null!;
    }
}
