namespace Peiton.Contracts.CuentasGeneralesJustificadas;

public class GenerarCuentaGeneralJustificadaRequest
{
    public int TuteladoId { get; set; }
    public DateTime Desde { get; set; }
    public DateTime Hasta { get; set; }
    public string TipoCuentaGeneralJustificada {get; set; } = null!;
    public string? LugarFallecimiento { get; set; }
    public int[] Archivos { get; set; } = [];
}