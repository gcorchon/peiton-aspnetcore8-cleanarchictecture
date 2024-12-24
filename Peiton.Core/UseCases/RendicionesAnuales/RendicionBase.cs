using Peiton.Core.Entities;

namespace Peiton.Core.UseCases.RendicionesAnuales;

public class RendicionBase
{
    public Tutelado Tutelado { get; set; } = null!;
    public DateTime FechaDesde { get; set; }
    public DateTime FechaHasta { get; set; }
}