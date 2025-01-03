﻿namespace Peiton.Authorization;

public struct PeitonPermission
{
    public const int Administrar = 33;
    public const int AdministrarCentros = 34;
    public const int AdministrarCentrosEditar = 105;
    public const int AdministrarComunicados = 252;
    public const int AdministrarDesplegables = 35;
    public const int AdministrarDesplegablesAbogados = 36;
    public const int AdministrarDesplegablesAgenda = 189;
    public const int AdministrarDesplegablesAgentes = 107;
    public const int AdministrarDesplegablesBancos = 37;
    public const int AdministrarDesplegablesCategoriasArchivo = 114;
    public const int AdministrarDesplegablesCausasBaja = 108;
    public const int AdministrarDesplegablesCentrosOcupacionalesAMAS = 161;
    public const int AdministrarDesplegablesCoordinadoresSociales = 229;
    public const int AdministrarDesplegablesDiagnosticos = 109;
    public const int AdministrarDesplegablesDirectorioAMTA = 157;
    public const int AdministrarDesplegablesEconomicos = 38;
    public const int AdministrarDesplegablesEducadoresSociales = 153;
    public const int AdministrarDesplegablesJuzgados = 39;
    public const int AdministrarDesplegablesNombramientos = 40;
    public const int AdministrarDesplegablesPartidosJudiciales = 110;
    public const int AdministrarDesplegablesProcedimientos = 111;
    public const int AdministrarDesplegablesProvincias = 41;
    public const int AdministrarDesplegablesReferenteDF = 203;
    public const int AdministrarDesplegablesSeguros = 112;
    public const int AdministrarDesplegablesSociales = 42;
    public const int AdministrarDesplegablesTecnicosIntegracionSocial = 182;
    public const int AdministrarDesplegablesTipoDeDocumento = 43;
    public const int AdministrarDesplegablesTipoDeInmueble = 44;
    public const int AdministrarDesplegablesTipoDeUtilizacion = 45;
    public const int AdministrarDesplegablesTiposPension = 113;
    public const int AdministrarDesplegablesTributos = 156;
    public const int AdministrarEntidadesGestoras = 171;
    public const int AdministrarGestionUsuarios = 47;
    public const int AdministrarGestionUsuariosDesbloquear = 170;
    public const int AdministrarGestionUsuariosGrupos = 49;
    public const int AdministrarGestionUsuariosGruposEditar = 128;
    public const int AdministrarGestionUsuariosUsuarios = 48;
    public const int AdministrarLogDeAccesos = 46;
    public const int AdministrarSucursales = 172;
    public const int AdministrarTraspasos = 179;
    public const int AdministrarVehiculos = 235;
    public const int AdministrarSalas = 258;

    public const int Categorizador = 120;

    public const int Comunicaciones = 32;
    public const int ComunicacionesLlamadas = 149;
    public const int ComunicacionesMensajes = 116;
    public const int ComunicacionesMensajesTuAppoyo = 341;
    public const int ComunicacionesNotificaciones = 117;
    public const int ComunicacionesRecibirMensajesPorEmail = 121;

    public const int ContabilidadAdministrar = 225;
    public const int ContabilidadAdministrarClientes = 226;
    public const int ContabilidadAnosPresupuestarios = 211;
    public const int ContabilidadAnosPresupuestariosAnosPresupuestarios = 212;
    public const int ContabilidadAnosPresupuestariosCapitulosYPartidas = 213;
    public const int ContabilidadAsientosYSaldos = 217;
    public const int ContabilidadAsientosYSaldosAsientos = 218;
    public const int ContabilidadAsientosYSaldosSaldos = 219;
    public const int ContabilidadFacturas = 220;
    public const int ContabilidadFondos = 221;
    public const int ContabilidadFondosFondoBankia = 224;
    public const int ContabilidadFondosFondoTotal = 222;
    public const int ContabilidadFondosFondoTutela = 223;
    public const int ContabilidadNuevosMovimientos = 214;
    public const int ContabilidadNuevosMovimientosMovimientosPendientesBanco = 215;
    public const int ContabilidadNuevosMovimientosMovimientosPendientesCaja = 216;
    public const int ContabilidadVales = 238;
    public const int ContabilidadValesAutorizar = 240;
    public const int ContabilidadValesPagar = 241;
    public const int ContabilidadValesRevisar = 239;

    public const int Contapeiton = 126;

    public const int GestionIndividual = 1;
    public const int GestionIndividualAgenda = 5;
    public const int GestionIndividualAgendaCrear = 83;
    public const int GestionIndividualAgendaEditar = 68;
    public const int GestionIndividualAgendaEliminar = 104;
    public const int GestionIndividualAppMovil = 187;
    public const int GestionIndividualBancos = 6;
    public const int GestionIndividualBancosCertificados = 7;
    public const int GestionIndividualBancosEscritosSucursales = 8;
    public const int GestionIndividualBancosExtractoBancario = 9;
    public const int GestionIndividualBancosImportarMovimientos = 10;
    public const int GestionIndividualBancosPosicionGlobal = 11;
    public const int GestionIndividualBancosPosicionGlobalBorrarProductos = 81;
    public const int GestionIndividualBancosPosicionGlobalRecategorizar = 82;
    public const int GestionIndividualBancosPosicionGlobalReseatearCredenciales = 80;
    public const int GestionIndividualBancosPosicionGlobalUnificar = 200;
    public const int GestionIndividualCaja = 12;
    public const int GestionIndividualCajaCrearIngreso = 106;
    public const int GestionIndividualCajaCrearNuevo = 75;
    public const int GestionIndividualCajaEliminar = 198;
    public const int GestionIndividualCrearNuevo = 73;
    public const int GestionIndividualDatosEconomicos = 4;
    public const int GestionIndividualDatosEconomicosAveriguacionPatrimonial = 231;
    public const int GestionIndividualDatosEconomicosBorrarCredenciales = 136;
    public const int GestionIndividualDatosEconomicosCaja = 145;
    public const int GestionIndividualDatosEconomicosCajaEditar = 146;
    public const int GestionIndividualDatosEconomicosCredenciales = 102;
    public const int GestionIndividualDatosEconomicosCredencialesEditar = 103;
    public const int GestionIndividualDatosEconomicosCredencialesVerLogEjecucion = 253;
    public const int GestionIndividualDatosEconomicosCredencialesForzarCredencial = 344;
    public const int GestionIndividualDatosEconomicosCuentas = 86;
    public const int GestionIndividualDatosEconomicosCuentasEditar = 87;
    public const int GestionIndividualDatosEconomicosDerechos = 94;
    public const int GestionIndividualDatosEconomicosDerechosEditar = 95;
    public const int GestionIndividualDatosEconomicosDerechosDeCredito = 259;
    public const int GestionIndividualDatosEconomicosDerechosDeCreditoEditar = 260;

    public const int GestionIndividualDatosEconomicosDeudas = 100;
    public const int GestionIndividualDatosEconomicosDeudasEditar = 101;
    public const int GestionIndividualDatosEconomicosDeudasManuales = 183;
    public const int GestionIndividualDatosEconomicosDeudasManualesEditar = 184;
    public const int GestionIndividualDatosEconomicosEfectosPublicos = 88;
    public const int GestionIndividualDatosEconomicosEfectosPublicosEditar = 89;
    public const int GestionIndividualDatosEconomicosFondoSolidario = 266;
    public const int GestionIndividualDatosEconomicosFondoSolidarioEditar = 267;

    public const int GestionIndividualDatosEconomicosGestoria = 162;
    public const int GestionIndividualDatosEconomicosGestoriaEditar = 163;
    public const int GestionIndividualDatosEconomicosInmuebles = 90;
    public const int GestionIndividualDatosEconomicosInmueblesAvisos = 135;
    public const int GestionIndividualDatosEconomicosInmueblesEditar = 91;
    public const int GestionIndividualDatosEconomicosInmueblesEliminar = 119;
    public const int GestionIndividualDatosEconomicosOtrosBienes = 92;
    public const int GestionIndividualDatosEconomicosOtrosBienesEditar = 93;
    public const int GestionIndividualDatosEconomicosOtrosDatos = 96;
    public const int GestionIndividualDatosEconomicosOtrosDatosEditar = 97;
    public const int GestionIndividualDatosEconomicosPlanesDePensiones = 261;
    public const int GestionIndividualDatosEconomicosPlanesDePensionesEditar = 262;
    public const int GestionIndividualDatosEconomicosPrestamos = 98;
    public const int GestionIndividualDatosEconomicosPrestamosEditar = 99;
    public const int GestionIndividualDatosEconomicosSegurosAhorro = 201;
    public const int GestionIndividualDatosEconomicosSegurosAhorroEditar = 202;
    public const int GestionIndividualDatosEconomicosSueldosYPensiones = 84;
    public const int GestionIndividualDatosEconomicosSueldosYPensionesEditar = 85;
    public const int GestionIndividualDatosEconomicosTributos = 154;
    public const int GestionIndividualDatosEconomicosTributosModificarIRPF = 332;
    public const int GestionIndividualDatosEconomicosTributosEditar = 155;
    public const int GestionIndividualDatosEconomicosVehiculos = 164;
    public const int GestionIndividualDatosEconomicosVehiculosEditar = 165;
    public const int GestionIndividualDatosJuridicos = 66;
    public const int GestionIndividualDatosJuridicosBorrar = 74;
    public const int GestionIndividualDatosJuridicosEditar = 67;
    public const int GestionIndividualDatosJuridicosEstado = 188;
    public const int GestionIndividualDatosJuridicosEstadoEditar = 194;
    public const int GestionIndividualDatosJuridicosFechasComunicacion = 199;
    public const int GestionIndividualDatosJuridicosFechasComunicacionFechaComunicacionBajaJuzgado = 343;
    public const int GestionIndividualDatosJuridicosFechasReconocimiento = 207;
    public const int GestionIndividualDatosJuridicosGestoresAdministrativos = 359;
    public const int GestionIndividualDatosJuridicosLeyNueva = 346;
    public const int GestionIndividualDatosJuridicosLeyNuevaCuratelaAsistencial = 347;
    public const int GestionIndividualDatosJuridicosLeyNuevaCuratelaRepresentativa = 348;
    public const int GestionIndividualDatosJuridicosLeyNuevaDefensaJudicialImpropia = 349;
    public const int GestionIndividualDatosJuridicosLeyNuevaAdministracionProvisional = 350;
    public const int GestionIndividualDatosJuridicosLeyNuevaInformeDeApoyos = 351;
    public const int GestionIndividualDatosJuridicosLeyNuevaInterviniente = 352;
    public const int GestionIndividualDatosJuridicosLeyNuevaUrgencia253 = 353;
    public const int GestionIndividualDatosJuridicosLeyNuevaDefensorJudicial = 354;
    public const int GestionIndividualDatosJuridicosLeyNuevaDefensorJudicialConAdministracionDeBienes = 355;
    public const int GestionIndividualDatosJuridicosLeyNuevaDefensorJudicialConIngresoInvoluntario = 356;
    public const int GestionIndividualDatosJuridicosLeyNuevaCuradorProvisional = 357;

    public const int GestionIndividualDatosJuridicosModificarDocumentos = 210;

    public const int GestionIndividualDatosPersonales = 2;
    public const int GestionIndividualDatosPersonalesAmbito = 174;
    public const int GestionIndividualDatosPersonalesAmbitoEditar = 175;
    public const int GestionIndividualDatosPersonalesAutorizado = 166;
    public const int GestionIndividualDatosPersonalesAutorizadoEditar = 167;
    public const int GestionIndividualDatosPersonalesBaja = 56;
    public const int GestionIndividualDatosPersonalesBajaEditar = 57;
    public const int GestionIndividualDatosPersonalesContactos = 52;
    public const int GestionIndividualDatosPersonalesContactosEditar = 53;
    public const int GestionIndividualDatosPersonalesDatosGenerales = 54;
    public const int GestionIndividualDatosPersonalesDatosGeneralesEditar = 55;

    public const int GestionIndividualDatosPersonalesDesplegableAbogado = 58;
    public const int GestionIndividualDatosPersonalesDesplegableAbogadoEditar = 59;
    public const int GestionIndividualDatosPersonalesDesplegableCoordinadorSocial = 227;
    public const int GestionIndividualDatosPersonalesDesplegableCoordinadorSocialEditar = 228;
    public const int GestionIndividualDatosPersonalesDesplegableEconomico = 60;
    public const int GestionIndividualDatosPersonalesDesplegableEconomicoEditar = 61;
    public const int GestionIndividualDatosPersonalesDesplegableEducadorSocial = 151;
    public const int GestionIndividualDatosPersonalesDesplegableEducadorSocialEditar = 152;
    public const int GestionIndividualDatosPersonalesDesplegableReferenteDF = 204;
    public const int GestionIndividualDatosPersonalesDesplegableReferenteDFEditar = 205;
    public const int GestionIndividualDatosPersonalesDesplegableTecnicoIntegracionSocial = 180;
    public const int GestionIndividualDatosPersonalesDesplegableTecnicoIntegracionSocialEditar = 181;
    public const int GestionIndividualDatosPersonalesDesplegableTrabajadorSocial = 62;
    public const int GestionIndividualDatosPersonalesDesplegableTrabajadorSocialEditar = 63;
    public const int GestionIndividualDatosPersonalesEntidadGestora = 177;
    public const int GestionIndividualDatosPersonalesEntidadGestoraEditar = 178;
    public const int GestionIndividualDatosPersonalesEquipoDefinitivo = 325;
    public const int GestionIndividualDatosPersonalesEquipoDefinitivoEditar = 325;
    public const int GestionIndividualDatosPersonalesExpedienteVinculado = 264;
    public const int GestionIndividualDatosPersonalesExpedienteVinculadoEditar = 265;
    public const int GestionIndividualDatosPersonalesNivelDeSoporte = 173;
    public const int GestionIndividualDatosPersonalesNivelDeSoporteEditar = 176;
    public const int GestionIndividualDatosPersonalesNumeroExpediente = 118;
    public const int GestionIndividualDatosPersonalesNoTutelado = 263;
    public const int GestionIndividualDatosPersonalesResidencia = 64;
    public const int GestionIndividualDatosPersonalesResidenciaEditar = 65;
    public const int GestionIndividualDatosPersonalesResidenciaGeolocalizacion = 255;
    public const int GestionIndividualDatosPersonalesResidenciaGeolocalizacionEditar = 256;
    public const int GestionIndividualDatosPersonalesSeguros = 50;
    public const int GestionIndividualDatosPersonalesSegurosEditar = 51;
    public const int GestionIndividualDatosPersonalesValoracion = 196;
    public const int GestionIndividualDatosPersonalesValoracionEditar = 197;
    public const int GestionIndividualDatosPersonalesVoluntades = 245;
    public const int GestionIndividualDatosPersonalesVoluntadesEditar = 246;
    public const int GestionIndividualDatosSociales = 3;
    public const int GestionIndividualDatosSocialesEditar = 130;
    public const int GestionIndividualDatosSocialesEstimacionFinancera = 185;
    public const int GestionIndividualDatosSocialesEstimacionFinanceraEditar = 186;
    public const int GestionIndividualDocumentos = 13;
    public const int GestionIndividualDocumentosAcogida = 335;
    public const int GestionIndividualDocumentosAutorizaciones = 160;
    public const int GestionIndividualDocumentosCajaFisica = 147;
    public const int GestionIndividualDocumentosEconomicos = 139;
    public const int GestionIndividualDocumentosEditar = 77;
    public const int GestionIndividualDocumentosEmpleadosHogar = 143;
    public const int GestionIndividualDocumentosInmuebles = 138;
    public const int GestionIndividualDocumentosJuridicos = 140;
    public const int GestionIndividualDocumentosNuevo = 76;
    public const int GestionIndividualDocumentosOtros = 144;
    public const int GestionIndividualDocumentosProcedimientosAdicionales = 230;
    public const int GestionIndividualDocumentosRendiciones = 362;
    public const int GestionIndividualDocumentosRSAT = 141;
    public const int GestionIndividualDocumentosSalud = 206;
    public const int GestionIndividualDocumentosSociales = 142;
    public const int GestionIndividualDocumentosTributarios = 148;
    public const int GestionIndividualDocumentosValoracion = 208;
    public const int GestionIndividualEmergencias = 129;
    public const int GestionIndividualEmergenciasCentros = 137;
    public const int GestionIndividualInformes = 14;
    public const int GestionIndividualInformesControlDeEscritos = 19;
    public const int GestionIndividualInformesControlDeEscritosEditar = 78;
    public const int GestionIndividualInformesCuentaGeneralJustificada = 16;
    public const int GestionIndividualInformesFichadebaja = 169;
    public const int GestionIndividualInformesHistoricoDeValidaciones = 20;
    public const int GestionIndividualInformesHistoricoDeValidacionesPia = 244;
    public const int GestionIndividualInformesInformeSituacion = 327;
    public const int GestionIndividualInformesInformePersonal = 21;
    public const int GestionIndividualInformesInventarioJudicial = 15;
    public const int GestionIndividualInformesPia = 243;
    public const int GestionIndividualInformesGeneradorDocumentos = 275;
    public const int GestionIndividualInformesRendicionAnualDeCuentas = 17;
    public const int GestionIndividualLlamadas = 150;
    public const int GestionIndividualTareas = 336;
    public const int GestionIndividualTareasEditar = 337;
    public const int GestionIndividualTareasCrear = 338;
    public const int GestionIndividualTareasEliminar = 339;
    public const int GestionIndividualTeAppoyo = 340;

    public const int GestionMasiva = 22;
    public const int GestionMasivaAvisosTributarios = 168;
    public const int GestionMasivaBancos = 23;
    public const int GestionMasivaBancosCredenciales = 158;
    public const int GestionMasivaBancosDesbloquearCredenciales = 358;
    public const int GestionMasivaCaja = 24;
    public const int GestionMasivaCajaBorrarCajaAMTA = 115;
    public const int GestionMasivaConsultas = 25;
    public const int GestionMasivaConsultasAlmacenadas = 26;
    public const int GestionMasivaConsultasAlmacenadasEditar = 69;
    public const int GestionMasivaConsultasManuales = 27;

    public const int GestionMasivaFondos = 324;
    public const int GestionMasivaFondoSolidario = 268;
    public const int GestionMasivaFondoSolidarioAutorizarTodo = 269;
    public const int GestionMasivaFondoSolidarioAutorizarParcial = 270;
    public const int GestionMasivaFondoSolidarioRevisar = 271;
    public const int GestionMasivaFondoSolidarioPagar = 272;
    public const int GestionMasivaFondoSolidarioVerificar = 273;

    public const int GestionMasivaGeolocalizacion = 254;
    public const int GestionMasivaGestoresAdministrativos = 360;
    public const int GestionMasivaImportacionArchivos = 345;
    public const int GestionMasivaInformes = 28;
    public const int GestionMasivaInformesControlDeEscritos = 29;
    public const int GestionMasivaInformesRendicionAnualDeCuentas = 30;
    public const int GestionMasivaInmuebles = 31;
    public const int GestionMasivaInmueblesEditar = 79;
    public const int GestionMasivaSeguimiento = 195;
    public const int GestionMasivaTransferencias = 159;
    public const int GestionMasivaTransferenciasVerTodas = 242;
    public const int GestionMasivaUrgenciasFondoSolidario = 318;
    public const int GestionMasivaUrgenciasFondoSolidarioAutorizarParcial = 320;
    public const int GestionMasivaUrgenciasFondoSolidarioAutorizarTodo = 319;
    public const int GestionMasivaUrgenciasFondoSolidarioPagar = 322;
    public const int GestionMasivaUrgenciasFondoSolidarioRevisar = 321;
    public const int GestionMasivaUrgenciasFondoSolidarioVerificar = 323;
    public const int GestionMasivaVoluntariados = 233;
    public const int GestionMasivaVoluntariadosCrear = 234;

    public const int Home = 70;
    public const int HomeComunicados = 232;
    public const int HomeEscribirEnTablon = 72;
    public const int HomeFelicitaciones = 209;
    public const int HomeVales = 237;
    public const int HomeVerCalendariosDeOtros = 71;

    public const int Incidencias = 190;
    public const int IncidenciasActualizar = 192;
    public const int IncidenciasCrear = 191;
    public const int IncidenciasVerTodas = 193;

    public const int Institucional = 247;
    public const int InstitucionalAusencias = 330;
    public const int InstitucionalAusenciasBorrar = 331;
    public const int InstitucionalDocumentos = 248;
    public const int InstitucionalDocumentosEditar = 251;
    public const int InstitucionalDocumentosEliminar = 249;
    public const int InstitucionalDocumentosNuevo = 250;
    public const int InstitucionalProcesos = 122;
    public const int InstitucionalProcesosEditar = 125;
    public const int InstitucionalProcesosEliminar = 123;
    public const int InstitucionalProcesosNuevo = 124;
    public const int InstitucionalPuntoInformacion = 274;
    public const int InstitucionalQuejas = 328;
    public const int InstitucionalQuejasBorrar = 329;
    public const int InstitucionalSalas = 257;
    public const int InstitucionalSenalamientos = 131;
    public const int InstitucionalSenalamientosEditar = 133;
    public const int InstitucionalSenalamientosEliminar = 134;
    public const int InstitucionalSenalamientosNuevo = 132;
    public const int InstitucionalVehiculos = 236;
    public const int InstitucionalVisitas = 127;





    public const int Urgencias = 276;
    public const int UrgenciasAgenda = 278;
    public const int UrgenciasAgendaCrear = 293;
    public const int UrgenciasAgendaEditar = 290;
    public const int UrgenciasAgendaEliminar = 294;
    public const int UrgenciasCrearNuevo = 314;
    public const int UrgenciasDatosEconomicos = 315;
    public const int UrgenciasDatosEconomicosFondoSolidario = 316;
    public const int UrgenciasDatosEconomicosFondoSolidarioEditar = 317;
    public const int UrgenciasDatosPersonales = 277;
    public const int UrgenciasDatosPersonalesArchivo = 282;
    public const int UrgenciasDatosPersonalesArchivoEditar = 283;
    public const int UrgenciasDatosPersonalesBaja = 333;
    public const int UrgenciasDatosPersonalesBajaEditar = 334;
    public const int UrgenciasDatosPersonalesDatosGenerales = 280;
    public const int UrgenciasDatosPersonalesDatosGeneralesEditar = 281;
    public const int UrgenciasDatosPersonalesDatosJuridicos = 308;
    public const int UrgenciasDatosPersonalesDatosJuridicosEditar = 309;
    public const int UrgenciasDatosPersonalesDesplegableAbogado = 284;
    public const int UrgenciasDatosPersonalesDesplegableAbogadoEditar = 285;
    public const int UrgenciasDatosPersonalesDesplegableEconomico = 286;
    public const int UrgenciasDatosPersonalesDesplegableEconomicoEditar = 287;
    public const int UrgenciasDatosPersonalesDesplegableOrigen = 310;
    public const int UrgenciasDatosPersonalesDesplegableOrigenEditar = 311;
    public const int UrgenciasDatosPersonalesDesplegableTipo = 312;
    public const int UrgenciasDatosPersonalesDesplegableTipoEditar = 313;
    public const int UrgenciasDatosPersonalesDesplegableTrabajadorSocial = 288;
    public const int UrgenciasDatosPersonalesDesplegableTrabajadorSocialEditar = 289;
    public const int UrgenciasDocumentos = 279;
    public const int UrgenciasDocumentosAutorizaciones = 307;
    public const int UrgenciasDocumentosCajaFisica = 299;
    public const int UrgenciasDocumentosEconomicos = 304;
    public const int UrgenciasDocumentosEditar = 292;
    public const int UrgenciasDocumentosEmpleadosHogar = 297;
    public const int UrgenciasDocumentosInmuebles = 303;
    public const int UrgenciasDocumentosJuridicos = 305;
    public const int UrgenciasDocumentosNuevo = 291;
    public const int UrgenciasDocumentosOtros = 298;
    public const int UrgenciasDocumentosProcedimientosAdicionales = 306;
    public const int UrgenciasDocumentosRSAT = 295;
    public const int UrgenciasDocumentosSalud = 301;
    public const int UrgenciasDocumentosSociales = 296;
    public const int UrgenciasDocumentosTributarios = 300;
    public const int UrgenciasDocumentosValoracion = 302;
}


