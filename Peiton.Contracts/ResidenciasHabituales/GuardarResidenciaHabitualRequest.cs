using Peiton.Contracts.Centros;

namespace Peiton.Contracts.ResidenciasHabituales;

public class GuardarResidenciaHabitualRequest : ResidenciaHabitualBase
{
    public int? CentroId { get; set; }
}