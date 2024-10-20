namespace Peiton.Contracts.Quejas;

public class GuardarQuejaRequest
{
    public int TuteladoId { get; set; }
    public int QuejaTipoId { get; set; }
    public int QuejaTipoDenuncianteId { get; set; }
    public int? UsuarioId { get; set; }
    public int? UsuarioResponsableId { get; set; }
    public string? Numero { get; set; } = null!;
    public DateTime FechaEntrada { get; set; }
    public DateTime? FechaCierre { get; set; }
    public string? NombreDenunciante { get; set; }
    public string? DNIDenunciante { get; set; }
    public string? Resumen { get; set; }
    public int? QuejaTipoCierreId { get; set; }
    public bool ActuacionPendiente { get; set; }
    public string? Comentarios { get; set; }
    public int[] QuejaMotivos { get; set; } = null!;

    public string? Documento { get; set; }
}
