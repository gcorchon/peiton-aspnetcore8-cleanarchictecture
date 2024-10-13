using Microsoft.AspNetCore.Mvc;
using Peiton.ModelBinders;

namespace Peiton.Contracts.Asientos;

public class AsientosHuerfanosFilter
{
    public string? Numero { get; set; }

    public string? Capitulo { get; set; }
    public string? Partida { get; set; }
    public string? Movimiento { get; set; }
    public string? Concepto { get; set; }
    public string? Importe { get; set; }
    public string? FechaAutorizacion { get; set; }

    [BindProperty(BinderType = typeof(StringToIntArrayModelBinder))]
    public int[] NoIncluir { get; set; } = [];
}