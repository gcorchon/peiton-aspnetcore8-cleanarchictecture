namespace Peiton.Contracts.EscritosSucursales;

public class GenerarEscritoSucursalRequest
{
    public int EntidadFinancieraId { get; set; }
    public string Numero { get; set; } = null!;
    public bool BloqueoCuentasSI { get; set; }
    public bool BloqueoCuentasNO { get; set; }
    public bool SolicitarClave { get; set; }
    public bool CartaJuzgado { get; set; }
    public bool BajaSinClaves { get; set; }
    public bool DepuracionTitular { get; set; }
    public bool DepuracionCotitular { get; set; }
    public bool SolicitudExtracto { get; set; }
    public bool AperturaCuenta { get; set; }
    public bool Apertura2Cuentas { get; set; }
    public bool SolicitudSantander300 { get; set; }
    public bool SolicitudBastanteo { get; set; }
    public bool EscritoGeneral { get; set; }
}