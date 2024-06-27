namespace Peiton.Contracts.Inmuebles.DocumentosDePago
{
    public class DocumentoPago
    {
        public int CuentaSeleccionada { get; set; }
        public string? OtraCuentaTutelado { get; set; }
        public string? QuienPaga { get; set; } = null!;
        public int CuentaSeleccionadaEmpresa { get; set; }
        public string? OtraCuentaEmpresa { get; set; }
        public string? CuentaEmpresa { get; set; }
        public string? Observaciones { get; set; }
        public Coste? Coste { get; set; }
        public ListaCuentas? Cuentas { get; set; }
    }

    public class ListaCuentas
    {
        public CuentaDocumentoPago[] Tutelado { get; set; } = [];
        public CuentaDocumentoPago[] Amta { get; set; } = [];
        public CuentaDocumentoPago[] Banco { get; set; } = [];
    }

    public class CuentaDocumentoPago
    {
        public int Pk_Account { get; set; }
        public string NumeroCompleto { get; set; } = null!;
        public decimal? Saldo { get; set; }
        public DateTime? FechaSaldo { get; set; }
    }

    public class Coste
    {
        public Empresa Empresa { get; set; } = null!;
        public decimal? Importe { get; set; }
        public string? CosteId { get; set; }
    }

    public class Empresa
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Cuenta { get; set; } = null!;
    }
}
