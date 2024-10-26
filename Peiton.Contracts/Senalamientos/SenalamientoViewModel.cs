using Peiton.Contracts.Common;

namespace Peiton.Contracts.Senalamientos;

public class SenalamientoViewModel
{
    public DateTime? Fecha { get; set; }
    public string? Procedimiento { get; set; }
    public string? Descripcion { get; set; }
    public string? Tutelado { get; set; }
    public string? ProfesionalAsistente { get; set; }
    public bool MadridCapital { get; set; }
    public ListItem? AbogadoAsistente { get; set; }
    public ListItem? AbogadoAsignado { get; set; }
    public ListItem? Juzgado { get; set; }
}