using Peiton.Authorization;
using Peiton.Serialization;

namespace Peiton.Contracts.Tutelado.Response;
public class TuteladoViewModel
{
    public int Id { get; set; }
    public string NumeroExpediente { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido1 { get; set; } = string.Empty;
    public string? Apellido2 { get; set; }
    public string? Apellidos { get; set; }
    public string? DNI { get; set; }
    public DateTime? FechaCaducidad { get; set; }
    public string? Pasaporte { get; set; }
    public DateTime? FechaCaducidadPasaporte { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public int? NacionalidadId { get; set; }
    public int? EstadoCivilId { get; set; }
    public string? SeguridadSocial { get; set; }
    public string? Muface { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesDesplegableAbogado)]
    public int? AbogadoId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesDesplegableTrabajadorSocial)]
    public int? TrabajadorSocialId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesDesplegableEconomico)]
    public int? EconomicoId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesDesplegableEducadorSocial)]
    public int? EducadorSocialId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesBaja)]
    public bool Muerto { get; set; }
    public string Sexo { get; set; } = string.Empty;

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesBaja)]
    public int? MotivoMuertoId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesBaja)]
    public string? CajaDecesos { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesBaja)]
    public DateTime? FechaMuerto { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesBaja)]
    public string? NumeroArchivo { get; set; }
    public string? Foto { get; set; }

    public bool Perpol { get; set; }
    public string? NombreAutorizado { get; set; }
    public string? ApellidosAutorizado { get; set; }
    public DateTime? FechaNacimientoAutorizado { get; set; }
    public bool? Autoriza { get; set; }
    public string? DNIAutorizado { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesAmbito)]
    public int? AmbitoId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesNivelDeSoporte)]
    public int? NivelSoporteId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesEntidadGestora)]
    public int? EntidadGestoraId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesDesplegableTecnicoIntegracionSocial)]
    public int? TecnicoIntegracionSocialId { get; set; }
    public DateTime? FechaCreacion { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesVoluntades)]
    public string? UltimasVoluntades { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosJuridicosEstado)]
    public int? DatosJuridicosEstadoId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesExpedienteVinculado)]
    public string? ExpedienteVinculado { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesExpedienteVinculado)]
    public string? ParentescoExpedienteVinculado { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesExpedienteVinculado)]
    public string? ObservacionesExpedienteVinculado { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]
    public bool? Valoracion { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]
    public int? EntidadDerivanteId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]
    public int? ValoracionResultadoId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]
    public int? ValoracionDestinatarioId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]
    public DateTime? FechaEnvioValoracion { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]
    public DateTime? FechaArchivoValoracion { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]
    public string? DerivanteEspecifico { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]
    public int? ValoracionEstadoId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]

    public int? ValoracionMedidaPropuestaId { get; set; }
    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]

    public int? ValoracionProfesionalId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]
    public int? ValoracionTutorId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]
    public bool? InformePsicosocial { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesDesplegableReferenteDF)]
    public int? ReferenteDFId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]
    public int? ValoracionMedidaCautelarId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesDesplegableCoordinadorSocial)]
    public int? CoordinadorSocialId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]
    public int? ValoracionEntradaExpedienteId { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesVoluntades)]
    public string? Preferencia1 { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesVoluntades)]
    public string? Preferencia2 { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesVoluntades)]
    public string? Preferencia3 { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesVoluntades)]
    public string? Preferencia4 { get; set; }
    public bool NoBinario { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesNoTutelado)]
    public bool NoTutelado { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesValoracion)]
    public DateTime? ValoracionFechaRecepcionDocumentacion { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesBaja)]
    public string? LugarBaja { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesBaja)]
    public string? MunicipioBaja { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesEquipoDefinitivo)]
    public bool EquipoDefinitivo { get; set; }

    [SerializeIf(PeitonPermission.GestionIndividualDatosPersonalesEquipoDefinitivo)]
    public DateTime? FechaEquipoDefinitivo { get; set; }
}
