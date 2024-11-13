using Peiton.Contracts.ApoyosFormales;
using Peiton.Contracts.ApoyosInformales;
using Peiton.Contracts.GastosEstimacionFinanciera;
using Peiton.Contracts.IngresosEstimacionFinanciera;
using Peiton.Contracts.TuteladoDiagnosticos;
using Peiton.Contracts.TuteladoObjetivos;
using Peiton.Contracts.TuteladoSaludFisica;
using Peiton.Contracts.TuteladoSaludPsiquica;

namespace Peiton.Contracts.DatosSociales;

public class DatosSocialesViewModel
{
    public string? GradoDiscapacidad { get; set; }
    public int? DependenciaId { get; set; }
    public int? Grado { get; set; }
    public int? DondeReside { get; set; }
    public int? LugarResidenciaId { get; set; }
    public int? ConQuien { get; set; }
    public int? TipoRelacionFamiliarId { get; set; }
    public int? RelacionAMTAVisitaId { get; set; }
    public int? RelacionAMTAContactoId { get; set; }
    public int? EstadoSaludId { get; set; }
    public string? TextoEmpeoramiento { get; set; }
    public string? DatosAdicionales { get; set; }
    public int? AdaptacionCentroId { get; set; }
    public int? RelacionCentroResidentesId { get; set; }
    public int? RelacionCentroProfesionalesId { get; set; }
    public bool InformeSocialEnBlanco { get; set; }
    public string? EducadorSocial { get; set; }
    public int? CentroOcupacionalAMASId { get; set; }
    public int? PiaId { get; set; }
    public int? DiscapacidadId { get; set; }
    public bool? TerceraPersona { get; set; }
    public bool? BaremosMovilidadPersona { get; set; }
    public DateTime? Validez { get; set; }
    public string? ObservacionesSituacionSalud { get; set; }
    public int? OrientacionId { get; set; }
    public int? SituacionSaludId { get; set; }
    public string? ObservacionesSaludFisica { get; set; }
    public string? ObservacionesSaludPsiquica { get; set; }
    public string? ObservacionesAdicciones { get; set; }
    public string? ObservacionesApoyoFormal { get; set; }
    public string? ObservacionesApoyoInformal { get; set; }
    public string? NotasConvivencional { get; set; }
    public string? ObservacionesEstimacionFinanciera { get; set; }
    public int? HabilidadPracticaAlimentacionId { get; set; }
    public int? HabilidadPracticaHigienePersonalId { get; set; }
    public int? HabilidadPracticaVestidoId { get; set; }
    public int? HabilidadPracticaTareaDomesticaId { get; set; }
    public int? HabilidadPracticaSolicitarAsistenciaId { get; set; }
    public int? HabilidadPracticaAplicarseMedidasTerapeuticasId { get; set; }
    public int? HabilidadPracticaEvitarSituacionesRiesgoId { get; set; }
    public int? HabilidadPracticaPedirAyudaUrgenciaId { get; set; }
    public int? HabilidadPracticaDesplazamientoDentroDelHogarId { get; set; }
    public int? HabilidadPracticaDesplazamientoFueraDelHogarId { get; set; }
    public int? HabilidadPracticaDesplazamientoTransportePublicoId { get; set; }
    public string? ObservacionesHabilidadesPracticas { get; set; }
    public bool? FormativaCursando { get; set; }
    public int? FormativaAutonomiaFormativaId { get; set; }
    public bool? LaboralRealizando { get; set; }
    public int? TipoLaboralFormativaId { get; set; }
    public int? DuracionLaboralFormativaId { get; set; }
    public int? LaboralAutonomiaFormativaId { get; set; }
    public bool? OcioRealizando { get; set; }
    public int? OcioAutonomiaFormativaId { get; set; }
    public string? ObservacionesFormativa { get; set; }
    public bool? ServicioAyudaDomicilio { get; set; }
    public bool? Residencia { get; set; }
    public bool? CentroDeDia { get; set; }
    public int? TipoResidenciaId { get; set; }
    public int? TipoCentroDeDiaId { get; set; }
    public bool? ConvivencionalCentroNoPerfil { get; set; }
    public bool? ConvivencionalSalubridad { get; set; }
    public bool? ConvivencionalHabitabilidad { get; set; }
    public bool? ConvivencionalConfort { get; set; }
    public bool? ConvivencionalAccesibilidad { get; set; }
    public bool? ConvivencionalNecesidadesBasicas { get; set; }
    public string? Alergias { get; set; }
    public IEnumerable<TuteladoDiagnosticoViewModel> Diagnosticos { get; set; } = null!;
    public IEnumerable<TuteladoObjetivoViewModel> Objetivos { get; set; } = null!;
    public IEnumerable<int> TiposDiscapacidad { get; set; } = null!;
    public IEnumerable<int> ServiciosDiscapacidad { get; set; } = null!;
    public IEnumerable<int> PvssDiscapacidad { get; set; } = null!;
    public IEnumerable<TuteladoSaludFisicaViewModel> RegistrosSaludFisica { get; set; } = null!;
    public IEnumerable<TuteladoSaludPsiquicaViewModel> RegistrosSaludPsiquica { get; set; } = null!;

    public IEnumerable<int> AdiccionesComportamentales { get; set; } = null!;
    public IEnumerable<int> AdiccionesSustancias { get; set; } = null!;

    public IEnumerable<ApoyoFormalViewModel> ApoyosFormales { get; set; } = null!;
    public IEnumerable<ApoyoInformalViewModel> ApoyosInformales { get; set; } = null!;

    public IEnumerable<GastoEstimacionFinancieraViewModel> GastosEstimacionesFinancieras { get; set; } = null!;
    public IEnumerable<IngresoEstimacionFinancieraViewModel> IngresosEstimacionesFinancieras { get; set; } = null!;
}