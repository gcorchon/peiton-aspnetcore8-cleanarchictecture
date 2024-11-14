namespace Peiton.Core.Entities;
public class Tutelado
{
	public int Id { get; set; }
	public string NumeroExpediente { get; set; } = null!;
	public string Nombre { get; set; } = null!;
	public string Apellido1 { get; set; } = null!;
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
	public int? AbogadoId { get; set; }
	public int? TrabajadorSocialId { get; set; }
	public int? EconomicoId { get; set; }
	public int? EducadorSocialId { get; set; }
	public bool Muerto { get; set; }
	public string Sexo { get; set; } = null!;
	public int? MotivoMuertoId { get; set; }
	public string? CajaDecesos { get; set; }
	public DateTime? FechaMuerto { get; set; }
	public string? NumeroArchivo { get; set; }
	public decimal SaldoInicialCaja { get; set; }
	public string? NombreCompleto { get; set; }
	public string? Foto { get; set; }
	public string? CodigoGestoriaFondoTutela { get; set; }
	public string? CodigoGestoriaFondoBankia { get; set; }
	public bool Perpol { get; set; }
	public string? NombreAutorizado { get; set; }
	public string? ApellidosAutorizado { get; set; }
	public DateTime? FechaNacimientoAutorizado { get; set; }
	public bool? Autoriza { get; set; }
	public string? DNIAutorizado { get; set; }
	public bool RetribucionContinuada { get; set; }
	public int? AmbitoId { get; set; }
	public int? NivelSoporteId { get; set; }
	public int? EntidadGestoraId { get; set; }
	public int? TecnicoIntegracionSocialId { get; set; }
	public DateTime? FechaCreacion { get; set; }
	public string? UltimasVoluntades { get; set; }
	public int? DatosJuridicosEstadoId { get; set; }
	public string? ExpedienteVinculado { get; set; }
	public string? ParentescoExpedienteVinculado { get; set; }
	public string? ObservacionesExpedienteVinculado { get; set; }
	public bool? Valoracion { get; set; }
	public int? EntidadDerivanteId { get; set; }
	public int? ValoracionResultadoId { get; set; }
	public int? ValoracionDestinatarioId { get; set; }
	public DateTime? FechaEnvioValoracion { get; set; }
	public DateTime? FechaArchivoValoracion { get; set; }
	public string? DerivanteEspecifico { get; set; }
	public int? ValoracionEstadoId { get; set; }
	public int? ValoracionMedidaPropuestaId { get; set; }
	public int? ValoracionProfesionalId { get; set; }
	public int? ValoracionTutorId { get; set; }
	public bool? InformePsicosocial { get; set; }
	public int? ReferenteDFId { get; set; }
	public int? ValoracionMedidaCautelarId { get; set; }
	public int? CoordinadorSocialId { get; set; }
	public int? ValoracionEntradaExpedienteId { get; set; }
	public string? Preferencia1 { get; set; }
	public string? Preferencia2 { get; set; }
	public string? Preferencia3 { get; set; }
	public string? Preferencia4 { get; set; }
	public bool NoBinario { get; set; }
	public bool NoTutelado { get; set; }
	public DateTime? ValoracionFechaRecepcionDocumentacion { get; set; }
	public string? LugarBaja { get; set; }
	public string? MunicipioBaja { get; set; }
	public bool EquipoDefinitivo { get; set; }
	public DateTime? FechaEquipoDefinitivo { get; set; }
	public DateTime? FechaEquipoDefinitivo2 { get; set; }
	public virtual CoordinadorSocial? CoordinadorSocial { get; set; }
	public virtual DatosEconomicos? DatosEconomicos { get; set; }
	public virtual DatosEconomicosCaja? DatosEconomicosCaja { get; set; }
	public virtual DatosJuridicos? DatosJuridicos { get; set; }
	public virtual DatosJuridicosEstado? DatosJuridicosEstado { get; set; }
	public virtual DatosSociales? DatosSociales { get; set; }
	public virtual EntidadDerivante? EntidadDerivante { get; set; }
	public virtual EntidadGestora? EntidadGestora { get; set; }
	public virtual NivelSoporte? NivelSoporte { get; set; }
	public virtual ReferenteDF? ReferenteDF { get; set; }
	public virtual TecnicoIntegracionSocial? TecnicoIntegracionSocial { get; set; }
	public virtual Abogado? Abogado { get; set; }
	public virtual Ambito? Ambito { get; set; }
	public virtual Economico? Economico { get; set; }
	public virtual EducadorSocial? EducadorSocial { get; set; }
	public virtual EstadoCivil? EstadoCivil { get; set; }
	public virtual MotivoMuerto? MotivoMuerto { get; set; }
	public virtual Nacionalidad? Nacionalidad { get; set; }
	public virtual ResidenciaHabitual? ResidenciaHabitual { get; set; }
	public virtual TeAppoyo? TeAppoyo { get; set; }
	public virtual TrabajadorSocial? TrabajadorSocial { get; set; }
	public virtual ValoracionDestinatario? ValoracionDestinatario { get; set; }
	public virtual ValoracionEntradaExpediente? ValoracionEntradaExpediente { get; set; }
	public virtual ValoracionEstado? ValoracionEstado { get; set; }
	public virtual ValoracionMedidaCautelar? ValoracionMedidaCautelar { get; set; }
	public virtual ValoracionMedidaPropuesta? ValoracionMedidaPropuesta { get; set; }
	public virtual ValoracionProfesional? ValoracionProfesional { get; set; }
	public virtual ValoracionResultado? ValoracionResultado { get; set; }
	public virtual ValoracionTutor? ValoracionTutor { get; set; }
	public virtual ICollection<VwCajaAMTA> VwCajaAMTA { get; } = new List<VwCajaAMTA>();

	/* public virtual ICollection<Agenda> Entradas { get; } = new List<Agenda>(); */
	public virtual ICollection<ApoyoFormal> ApoyosFormales { get; } = new List<ApoyoFormal>();
	public virtual ICollection<ApoyoInformal> ApoyosInformales { get; } = new List<ApoyoInformal>();
	/* public virtual ICollection<AppMovilCita> AppMovilCitas { get; } = new List<AppMovilCita>(); */
	/* public virtual ICollection<AppMovilRegistroDiario> AppMovilRegistrosDiarios { get; } = new List<AppMovilRegistroDiario>(); */
	/* public virtual ICollection<AppMovilTarea> AppMovilTareas { get; } = new List<AppMovilTarea>(); */
	public virtual ICollection<AppMovilTutelado> AppMovilTutelados { get; } = new List<AppMovilTutelado>();
	/* public virtual ICollection<AppMovilTuteladoRecompensa> AppMovilTuteladosRecompensas { get; } = new List<AppMovilTuteladoRecompensa>(); */
	/* public virtual ICollection<Archivo> Archivos { get; } = new List<Archivo>(); */
	/* public virtual ICollection<Arrendamiento> Arrendamientos { get; } = new List<Arrendamiento>(); */
	public virtual ICollection<Asiento> Asientos { get; } = new List<Asiento>();
	/* public virtual ICollection<Autorizacion> Autorizaciones { get; } = new List<Autorizacion>(); */
	/* public virtual ICollection<AvisoTributario> AvisosTributarios { get; } = new List<AvisoTributario>(); */
	public virtual ICollection<CajaAMTA> CajaAMTA { get; } = new List<CajaAMTA>();

	public virtual ICollection<CajaIncidencia> CajaIncidencias { get; } = new List<CajaIncidencia>();
	/* public virtual ICollection<Cita> Citas { get; } = new List<Cita>(); */
	public virtual ICollection<Contacto> Contactos { get; } = new List<Contacto>();
	/* public virtual ICollection<ControlCuentaGeneral> ControlesCuentasGenerales { get; } = new List<ControlCuentaGeneral>(); */
	/* public virtual ICollection<ControlInventario> ControlesInventarios { get; } = new List<ControlInventario>(); */
	/* public virtual ICollection<ControlRendicion> ControlesRendiciones { get; } = new List<ControlRendicion>(); */
	public virtual ICollection<Credencial> Credenciales { get; } = new List<Credencial>();


	/* public virtual ICollection<DatosJuridicos> DatosJuridicos { get; } = new List<DatosJuridicos>(); */
	/* public virtual ICollection<DatosJuridicosHistorico> DatosJuridicosHistoricos { get; } = new List<DatosJuridicosHistorico>(); */
	/* public virtual ICollection<DatosSociales> DatosSociales { get; } = new List<DatosSociales>(); */
	/* public virtual ICollection<Deuda> Deudas { get; } = new List<Deuda>(); */
	/* public virtual ICollection<EfectoPublico> EfectosPublicos { get; } = new List<EfectoPublico>(); */
	/* public virtual ICollection<Emergencia> Emergencias { get; } = new List<Emergencia>(); */
	/* public virtual ICollection<EmergenciaCentro> EmergenciasCentros { get; } = new List<EmergenciaCentro>(); */
	/* public virtual ICollection<EscritoSucursal> EscritosSucursales { get; } = new List<EscritoSucursal>(); */
	/* public virtual ICollection<Evento> Eventos { get; } = new List<Evento>(); */
	/* public virtual ICollection<FondoSolidario> FondosSolidarios { get; } = new List<FondoSolidario>(); */
	public virtual ICollection<GastoEstimacionFinanciera> GastosEstimacionesFinancieras { get; } = new List<GastoEstimacionFinanciera>();
	public virtual ICollection<GestionAdministrativa> GestionesAdministrativas { get; } = new List<GestionAdministrativa>();
	/* public virtual ICollection<InformePersonal> InformesPersonales { get; } = new List<InformePersonal>(); */
	/* public virtual ICollection<InformePersonalPIA> InformesPersonalesPIA { get; } = new List<InformePersonalPIA>(); */
	public virtual ICollection<IngresoEstimacionFinanciera> IngresosEstimacionesFinancieras { get; } = new List<IngresoEstimacionFinanciera>();
	/* public virtual ICollection<Inmueble> Inmuebles { get; } = new List<Inmueble>(); */
	public virtual ICollection<MedidaPenal> MedidasPenales { get; } = new List<MedidaPenal>();
	/* public virtual ICollection<NotaSimple> NotasSimples { get; } = new List<NotaSimple>(); */
	public virtual ICollection<OtroAsunto> OtrosAsuntos { get; } = new List<OtroAsunto>();
	/* public virtual ICollection<PlanDePension> PlanesDePensiones { get; } = new List<PlanDePension>(); */
	/* public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>(); */
	public virtual ICollection<ProcedimientoAdicional> ProcedimientosAdicionales { get; } = new List<ProcedimientoAdicional>();
	/* public virtual ICollection<ProductoManual> ProductosManuales { get; } = new List<ProductoManual>(); */
	/* public virtual ICollection<Queja> Quejas { get; } = new List<Queja>(); */

	/* public virtual ICollection<SeguroAhorro> SegurosAhorros { get; } = new List<SeguroAhorro>(); */
	public virtual ICollection<SeguroContratado> SegurosContratados { get; } = new List<SeguroContratado>();
	/* public virtual ICollection<Senalamiento> Senalamientos { get; } = new List<Senalamiento>(); */
	/* public virtual ICollection<Sucesion> Sucesiones { get; } = new List<Sucesion>(); */
	public virtual ICollection<SueldoPension> SueldosPensiones { get; } = new List<SueldoPension>();
	/* public virtual ICollection<Tarea> Tareas { get; } = new List<Tarea>(); */
	/* public virtual ICollection<TareaAgenda> TareasEntradas { get; } = new List<TareaAgenda>(); */
	/* public virtual ICollection<TeAppoyo> TeAppoyos { get; } = new List<TeAppoyo>(); */
	/* public virtual ICollection<TributoTutelado> TributosTutelados { get; } = new List<TributoTutelado>(); */
	/* public virtual ICollection<TuteladoActividad> TuteladosActividades { get; } = new List<TuteladoActividad>(); */
	/* public virtual ICollection<TuteladoAllegado> TuteladosAllegados { get; } = new List<TuteladoAllegado>(); */
	/* public virtual ICollection<TuteladoCompania> TuteladosCompanias { get; } = new List<TuteladoCompania>(); */
	public virtual ICollection<TuteladoDiagnostico> TuteladosDiagnosticos { get; } = new List<TuteladoDiagnostico>();
	public virtual ICollection<TuteladoObjetivo> Objetivos { get; } = new List<TuteladoObjetivo>();
	/* public virtual ICollection<TuteladoRelacionConvivencional> TuteladosRelacionesConvivencionales { get; } = new List<TuteladoRelacionConvivencional>(); */
	public virtual ICollection<TuteladoSaludFisica> RegistrosSaludFisica { get; } = new List<TuteladoSaludFisica>();
	public virtual ICollection<TuteladoSaludPsiquica> RegistrosSaludPsiquica { get; } = new List<TuteladoSaludPsiquica>();
	/* public virtual ICollection<Vehiculo> Vehiculos { get; } = new List<Vehiculo>(); */
	/* public virtual ICollection<Voluntariado> Voluntariados { get; } = new List<Voluntariado>(); */
	public virtual ICollection<AdiccionComportamental> AdiccionesComportamentales { get; } = new List<AdiccionComportamental>();
	public virtual ICollection<AdiccionSustancia> AdiccionesSustancias { get; } = new List<AdiccionSustancia>();
	/* public virtual ICollection<ApoyoExterno> ApoyosExternos { get; } = new List<ApoyoExterno>(); */
	public virtual ICollection<DiscapacidadTipo> DiscapacidadesTipos { get; } = new List<DiscapacidadTipo>();
	public virtual ICollection<DiscapacidadPVS> DiscapacidadesPVSs { get; } = new List<DiscapacidadPVS>();
	public virtual ICollection<DiscapacidadServicio> DiscapacidadesServicios { get; } = new List<DiscapacidadServicio>();
	/* public virtual ICollection<TipoCuratela> TiposCuratelas { get; } = new List<TipoCuratela>(); */
	/* public virtual ICollection<TipoCuratela> TiposCuratelas { get; } = new List<TipoCuratela>(); */
	/* public virtual ICollection<TipoOrientacion> TiposOrientaciones { get; } = new List<TipoOrientacion>(); */
}
