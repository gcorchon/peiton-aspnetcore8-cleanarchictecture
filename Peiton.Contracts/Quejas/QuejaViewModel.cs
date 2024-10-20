using Peiton.Contracts.Common;

namespace Peiton.Contracts.Quejas;

public class QuejaViewModel
{
    public int Id { get; set; }

    public int QuejaTipoId { get; set; }
    public string Expediente { get; set; } = null!;
    public ListItem Tutelado { get; set; } = null!;
    public int QuejaTipoDenuncianteId { get; set; }
    public ListItem? Usuario { get; set; }
    public ListItem? UsuarioResponsable { get; set; }

    public DateTime FechaEntrada { get; set; }
    public DateTime? FechaCierre { get; set; }
    public int? DiasTranscurridos { get; set; }
    public string? NombreDenunciante { get; set; }
    public string? DNIDenunciante { get; set; }
    public string? Resumen { get; set; }
    public int? QuejaTipoCierreId { get; set; }
    public bool ActuacionPendiente { get; set; }
    public string? Comentarios { get; set; }
    public string? Numero { get; set; }

    public string? Documento { get; set; }
    public int[] QuejaMotivos { get; set; } = null!;
}

