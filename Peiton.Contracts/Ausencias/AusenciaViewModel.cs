using Peiton.Contracts.Common;

namespace Peiton.Contracts.Ausencias;

public class AusenciaViewModel
{
    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public ListItem Usuario { get; set; } = null!;
    public ListItem UsuarioSuplente { get; set; } = null!;
}

