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
	public virtual ICollection<VwCajaAMTA> VwCajaAMTA { get; } = [];
	public virtual ICollection<VwCaja> VwCaja { get; } = [];

	/* public virtual ICollection<Agenda> Entradas { get; } = []; */
	public virtual ICollection<ApoyoFormal> ApoyosFormales { get; } = [];
	public virtual ICollection<ApoyoInformal> ApoyosInformales { get; } = [];
	/* public virtual ICollection<AppMovilCita> AppMovilCitas { get; } = []; */
	/* public virtual ICollection<AppMovilRegistroDiario> AppMovilRegistrosDiarios { get; } = []; */
	/* public virtual ICollection<AppMovilTarea> AppMovilTareas { get; } = []; */
	public virtual ICollection<AppMovilTutelado> AppMovilTutelados { get; } = [];
	/* public virtual ICollection<AppMovilTuteladoRecompensa> AppMovilTuteladosRecompensas { get; } = []; */
	/* public virtual ICollection<Archivo> Archivos { get; } = []; */
	public virtual ICollection<Arrendamiento> Arrendamientos { get; } = [];
	public virtual ICollection<Asiento> Asientos { get; } = [];
	public virtual ICollection<Autorizacion> Autorizaciones { get; } = [];
	/* public virtual ICollection<AvisoTributario> AvisosTributarios { get; } = []; */
	public virtual ICollection<CajaAMTA> CajaAMTA { get; } = [];

	public virtual ICollection<CajaIncidencia> CajaIncidencias { get; } = [];
	public virtual ICollection<Cita> Citas { get; } = [];
	public virtual ICollection<Contacto> Contactos { get; } = [];
	/* public virtual ICollection<ControlCuentaGeneral> ControlesCuentasGenerales { get; } = []; */
	/* public virtual ICollection<ControlInventario> ControlesInventarios { get; } = []; */
	/* public virtual ICollection<ControlRendicion> ControlesRendiciones { get; } = []; */
	public virtual ICollection<Credencial> Credenciales { get; } = [];


	/* public virtual ICollection<DatosJuridicos> DatosJuridicos { get; } = []; */
	/* public virtual ICollection<DatosJuridicosHistorico> DatosJuridicosHistoricos { get; } = []; */
	/* public virtual ICollection<DatosSociales> DatosSociales { get; } = []; */
	/* public virtual ICollection<Deuda> Deudas { get; } = []; */
	public virtual ICollection<EfectoPublico> EfectosPublicos { get; } = [];
	/* public virtual ICollection<Emergencia> Emergencias { get; } = []; */
	/* public virtual ICollection<EmergenciaCentro> EmergenciasCentros { get; } = []; */
	public virtual ICollection<EscritoSucursal> EscritosSucursales { get; } = [];
	/* public virtual ICollection<Evento> Eventos { get; } = []; */
	/* public virtual ICollection<FondoSolidario> FondosSolidarios { get; } = []; */
	public virtual ICollection<GastoEstimacionFinanciera> GastosEstimacionesFinancieras { get; } = [];
	public virtual ICollection<GestionAdministrativa> GestionesAdministrativas { get; } = [];
	/* public virtual ICollection<InformePersonal> InformesPersonales { get; } = []; */
	/* public virtual ICollection<InformePersonalPIA> InformesPersonalesPIA { get; } = []; */
	public virtual ICollection<IngresoEstimacionFinanciera> IngresosEstimacionesFinancieras { get; } = [];
	public virtual ICollection<Inmueble> Inmuebles { get; } = [];
	public virtual ICollection<MedidaPenal> MedidasPenales { get; } = [];
	/* public virtual ICollection<NotaSimple> NotasSimples { get; } = []; */
	public virtual ICollection<OtroAsunto> OtrosAsuntos { get; } = [];
	/* public virtual ICollection<PlanDePension> PlanesDePensiones { get; } = []; */
	public virtual ICollection<Prestamo> Prestamos { get; } = [];
	public virtual ICollection<ProcedimientoAdicional> ProcedimientosAdicionales { get; } = [];
	public virtual ICollection<ProductoManual> ProductosManuales { get; } = [];
	/* public virtual ICollection<Queja> Quejas { get; } = []; */

	public virtual ICollection<SeguroAhorro> SegurosAhorro { get; } = [];
	public virtual ICollection<SeguroContratado> SegurosContratados { get; } = [];
	/* public virtual ICollection<Senalamiento> Senalamientos { get; } = []; */
	/* public virtual ICollection<Sucesion> Sucesiones { get; } = []; */
	public virtual ICollection<SueldoPension> SueldosPensiones { get; } = [];
	public virtual ICollection<Tarea> Tareas { get; } = [];
	public virtual ICollection<TareaAgenda> TareasAgenda { get; } = [];
	/* public virtual ICollection<TeAppoyo> TeAppoyos { get; } = []; */
	public virtual ICollection<TributoTutelado> TributosTutelados { get; } = [];
	/* public virtual ICollection<TuteladoActividad> TuteladosActividades { get; } = []; */
	/* public virtual ICollection<TuteladoAllegado> TuteladosAllegados { get; } = []; */
	/* public virtual ICollection<TuteladoCompania> TuteladosCompanias { get; } = []; */
	public virtual ICollection<TuteladoDiagnostico> TuteladosDiagnosticos { get; } = [];
	public virtual ICollection<TuteladoObjetivo> Objetivos { get; } = [];
	/* public virtual ICollection<TuteladoRelacionConvivencional> TuteladosRelacionesConvivencionales { get; } = []; */
	public virtual ICollection<TuteladoSaludFisica> RegistrosSaludFisica { get; } = [];
	public virtual ICollection<TuteladoSaludPsiquica> RegistrosSaludPsiquica { get; } = [];
	public virtual ICollection<Vehiculo> Vehiculos { get; } = [];
	/* public virtual ICollection<Voluntariado> Voluntariados { get; } = []; */
	public virtual ICollection<AdiccionComportamental> AdiccionesComportamentales { get; } = [];
	public virtual ICollection<AdiccionSustancia> AdiccionesSustancias { get; } = [];
	/* public virtual ICollection<ApoyoExterno> ApoyosExternos { get; } = []; */
	public virtual ICollection<DiscapacidadTipo> DiscapacidadesTipos { get; } = [];
	public virtual ICollection<DiscapacidadPVS> DiscapacidadesPVSs { get; } = [];
	public virtual ICollection<DiscapacidadServicio> DiscapacidadesServicios { get; } = [];
	/* public virtual ICollection<TipoCuratela> TiposCuratelas { get; } = []; */
	/* public virtual ICollection<TipoCuratela> TiposCuratelas { get; } = []; */
	/* public virtual ICollection<TipoOrientacion> TiposOrientaciones { get; } = []; */
}
