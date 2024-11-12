using Peiton.Contracts.Common;

namespace Peiton.Contracts.DatosJuridicos;

public class DatosJuridicosViewModel
{
    public ListItem? Juzgado { get; set; }
    public int? ProcedimientoId { get; set; }
    public string? NumeroProcedimiento { get; set; }
    public int? NombramientoId { get; set; }
    public int? PartidoJudicialInhibicionId { get; set; }
    public DateTime? FechaJura { get; set; }
    public DateTime? FechaNombramiento { get; set; }
    public DateTime? FechaFinCargo { get; set; }
    public DateTime? FechaSentencia { get; set; }
    public int? Nombramiento2Id { get; set; }
    public int? NivelIntensidadId { get; set; }
    public DateTime? FechaNotificacionSentencia { get; set; }
    public DateTime? FechaFirmeza { get; set; }
    public int? PartidoJudicialId { get; set; }
    public int? OrigenExpedienteId { get; set; }
    public DateTime? ComunicacionAreasCargo { get; set; }
    public DateTime? ComunicacionNombramiento { get; set; }
    public DateTime? ComunicacionJura { get; set; }
    public DateTime? ReconocimientoForense { get; set; }
    public DateTime? ReconocimientoJudicial { get; set; }
    public int? ArchivoDocumentoJuraId { get; set; }
    public int? ArchivoResolucionJudicialId { get; set; }
    public int? ArchivoResolucionJudicialAutoId { get; set; }
    public int? SolicitanteRevisionId { get; set; }
    public bool SentenciaRevisada { get; set; }
    public DateTime? FechaRevision { get; set; }
    public int? GradoApoyoId { get; set; }
    public int LeyNombramientoId { get; set; }
    public bool EsCuratelaAsistencial { get; set; }
    public bool EsCuratelaRepresentativa { get; set; }
    public bool NoPresentarRendicion { get; set; }
    public string? Observaciones { get; set; }
    public DateTime? FechaSolicitudAveriguacionPatrimonial { get; set; }
    public DateTime? FechaRecepcionAveriguacionPatrimonial { get; set; }
    public bool NuevoInventarioRevision { get; set; }
    public bool RendicionFinalRevision { get; set; }
    public DateTime? RendicionPeriodica { get; set; }
    public string? Comentarios { get; set; }
    public decimal? LimiteGastoExtraOrdinario { get; set; }
    public bool PresentarLexnet { get; set; }
    public DateTime? FechaComunicacionBajaJuzgado { get; set; }
    //public virtual SolicitanteRevision? SolicitanteRevision { get; set; }
}