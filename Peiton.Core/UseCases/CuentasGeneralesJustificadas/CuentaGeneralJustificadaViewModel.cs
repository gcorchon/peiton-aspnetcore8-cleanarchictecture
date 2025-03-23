using Peiton.Core.Entities;

namespace Peiton.Core.UseCases.CuentasGeneralesJustificadas;

public class CuentaGeneralJustificadaViewModel
{
    public Tutelado Tutelado { get; set; } = null!;
    public string? LugarFallecimiento { get; set; } = null!;
    public DateTime Desde { get; set; }
    public DateTime Hasta { get; set; }
}