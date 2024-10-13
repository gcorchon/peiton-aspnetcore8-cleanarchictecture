namespace Peiton.Contracts.Inmuebles;

public class ListaCuentas
{
    public CuentaDocumentoPago[] Tutelado { get; set; } = [];
    public CuentaDocumentoPago[] Amta { get; set; } = [];
    public CuentaDocumentoPago[] Banco { get; set; } = [];
}

