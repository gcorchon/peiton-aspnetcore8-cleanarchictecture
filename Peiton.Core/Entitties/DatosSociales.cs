namespace Peiton.Core.Entities;
public class DatosSociales
{
	public int TuteladoId { get; set; }
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
	public virtual AdaptacionCentro? AdaptacionCentro { get; set; }
	public virtual CentroOcupacionalAMAS? CentroOcupacionalAMAS { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;
	public virtual Dependencia? Dependencia { get; set; }
	public virtual EstadoSalud? EstadoSalud { get; set; }
	public virtual LugarResidencia? LugarResidencia { get; set; }
	public virtual RelacionAMTAContacto? RelacionAMTAContacto { get; set; }
	public virtual RelacionAMTAVisita? RelacionAMTAVisita { get; set; }
	public virtual RelacionCentroProfesionales? RelacionCentroProfesionales { get; set; }
	public virtual RelacionCentroResidentes? RelacionCentroResidentes { get; set; }
	public virtual TipoRelacionFamiliar? TipoRelacionFamiliar { get; set; }
	public virtual Discapacidad? Discapacidad { get; set; }
	public virtual DuracionLaboralFormativa? DuracionLaboralFormativa { get; set; }
	public virtual AutonomiaFormativa? FormativaAutonomiaFormativa { get; set; }
	public virtual HabilidadPractica? HabilidadPracticaAlimentacion { get; set; }
	public virtual HabilidadPractica? HabilidadPracticaAplicarseMedidasTerapeuticas { get; set; }
	public virtual HabilidadPractica? HabilidadPracticaDesplazamientoDentroDelHogar { get; set; }
	public virtual HabilidadPractica? HabilidadPracticaDesplazamientoFueraDelHogar { get; set; }
	public virtual HabilidadPractica? HabilidadPracticaDesplazamientoTransportePublico { get; set; }
	public virtual HabilidadPractica? HabilidadPracticaEvitarSituacionesRiesgo { get; set; }
	public virtual HabilidadPractica? HabilidadPracticaHigienePersonal { get; set; }
	public virtual HabilidadPractica? HabilidadPracticaPedirAyudaUrgencia { get; set; }
	public virtual HabilidadPractica? HabilidadPracticaSolicitarAsistencia { get; set; }
	public virtual HabilidadPractica? HabilidadPracticaTareaDomestica { get; set; }
	public virtual HabilidadPractica? HabilidadPracticaVestido { get; set; }
	public virtual AutonomiaFormativa? LaboralAutonomiaFormativa { get; set; }
	public virtual AutonomiaFormativa? OcioAutonomiaFormativa { get; set; }
	public virtual Orientacion? Orientacion { get; set; }
	public virtual Pia? Pia { get; set; }
	public virtual SituacionSalud? SituacionSalud { get; set; }
	public virtual TipoResidencia? TipoCentroDeDia { get; set; }
	public virtual TipoLaboralFormativa? TipoLaboralFormativa { get; set; }
	public virtual TipoResidencia? TipoResidencia { get; set; }

}
