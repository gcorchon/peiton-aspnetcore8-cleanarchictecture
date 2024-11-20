namespace Peiton.Contracts.Seguimientos;

public class CrearSeguimientoMasivoRequest
{
    public int[] TuteladoIds { get; set; } = null!;
    public int CategoriaAgendaId { get; set; }
    public string Descripcion { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public int? AgendaActuacionId { get; set; }
    public bool? Realizada { get; set; }
    public int? Minutos { get; set; }
    public int? AgendaAreaActuacionId { get; set; }

}