namespace Peiton.Contracts.Facturas;

public static class EstadoFactura 
{
    private static Dictionary<int, string> estados = new Dictionary<int, string>()
    {
        { 1, "Aceptada" },
        { 2, "Devuelta" },
        { 3, "Anulada" }
    };

    public static string GetText(int key) => EstadoFactura.estados[key];
}