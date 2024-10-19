namespace Peiton.Contracts.Ausencias;

public class AusenciasFilter
{
    public DateTime? FechaIntervalo { get; set; }
    public string? FechaInicio { get; set; }
    public string? FechaFin { get; set; }

    public string? Usuario { get; set; }
    public string? UsuarioSuplente { get; set; }
}

