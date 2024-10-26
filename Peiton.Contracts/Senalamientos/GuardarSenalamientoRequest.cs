using Peiton.Contracts.Common;

namespace Peiton.Contracts.Senalamientos;

public class GuardarSenalamientoRequest
{
    public DateTime? Fecha { get; set; }
    public string? Procedimiento { get; set; }
    public string? Descripcion { get; set; }
    public string? Tutelado { get; set; }
    public string? ProfesionalAsistente { get; set; }
    public bool MadridCapital { get; set; }
    public int? AbogadoAsistenteId { get; set; }
    public int? AbogadoAsignadoId { get; set; }
    public int? JuzgadoId { get; set; }
}