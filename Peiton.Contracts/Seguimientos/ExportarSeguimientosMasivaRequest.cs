using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Peiton.Contracts.Seguimientos;

public class ExportarSeguimientosMasivaRequest
{
    [BindRequired]
    public DateTime FechaInicio { get; set; }
    [BindRequired]
    public DateTime FechaFin { get; set; }
    public int? CategoriaAgendaId { get; set; }
    public int? UsuarioId { get; set; }
}