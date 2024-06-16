namespace Peiton.Core.Entities
{
    public class Usuario
	{
		public int Id { get; set; }
		public string Username { get; set; } = null!;
		public string Pwd { get; set; } = null!;
		public string Firma { get; set; } = null!;
		public int Reintentos { get; set; }
		public string Nombre { get; set; } = null!;
		public string Apellidos { get; set; } = null!;
		public string? Info { get; set; }
		public string Email { get; set; } = null!;
		public bool Bloqueado { get; set; }
		public bool Borrado { get; set; }
		public bool MostrarEnHome { get; set; }
		public string NombreCompleto { get; set; } = null!;
		public string Imagen { get; set; } = null!;
		public string Cargo { get; set; } = null!;
		public string? TelefonoFijo { get; set; }
		public string? TelefonoMovil { get; set; }
		public string? UserAgent { get; set; }

		/* public virtual ICollection<Agenda> Entradas { get; } = new List<Agenda>(); */
		/* public virtual ICollection<Ausencia> AusenciasUsuario { get; } = new List<Ausencia>(); */
		/* public virtual ICollection<Ausencia> AusenciasUsuarioSuplente { get; } = new List<Ausencia>(); */
		/* public virtual ICollection<Autorizacion> Autorizaciones { get; } = new List<Autorizacion>(); */
		/* public virtual ICollection<AvisoTributario> AvisosTributarios { get; } = new List<AvisoTributario>(); */
		/* public virtual ICollection<Caja> CajaUsuario { get; } = new List<Caja>(); */
		/* public virtual ICollection<Caja> CajaPagador { get; } = new List<Caja>(); */
		/* public virtual ICollection<CajaIncidencia> CajaIncidencias { get; } = new List<CajaIncidencia>(); */
		/* public virtual ICollection<Cita> Citas { get; } = new List<Cita>(); */
		/* public virtual ICollection<Emergencia> Emergencias { get; } = new List<Emergencia>(); */
		/* public virtual ICollection<EmergenciaCentro> EmergenciasCentros { get; } = new List<EmergenciaCentro>(); */
		/* public virtual ICollection<Evento> Eventos { get; } = new List<Evento>(); */
		/* public virtual ICollection<FondoSolidario> FondosSolidariosRevisor { get; } = new List<FondoSolidario>(); */
		/* public virtual ICollection<FondoSolidario> FondosSolidariosAutorizador { get; } = new List<FondoSolidario>(); */
		/* public virtual ICollection<FondoSolidario> FondosSolidariosSolicitante { get; } = new List<FondoSolidario>(); */
		/* public virtual ICollection<FondoSolidario> FondosSolidariosPagador { get; } = new List<FondoSolidario>(); */
		/* public virtual ICollection<FondoSolidario> FondosSolidariosVerificador { get; } = new List<FondoSolidario>(); */
		/* public virtual ICollection<Incidencia> Incidencias { get; } = new List<Incidencia>(); */
		/* public virtual ICollection<InformePersonal> InformesPersonales { get; } = new List<InformePersonal>(); */
		/* public virtual ICollection<InformePersonalPIA> InformesPersonalesPIA { get; } = new List<InformePersonalPIA>(); */
		/* public virtual ICollection<InmuebleAutorizacion> InmueblesAutorizaciones { get; } = new List<InmuebleAutorizacion>(); */
		/* public virtual ICollection<InmuebleAviso> InmueblesAvisos { get; } = new List<InmuebleAviso>(); */
		/* public virtual ICollection<InmuebleSolicitudAlquilerVenta> InmueblesSolicitudesAlquileresVentas { get; } = new List<InmuebleSolicitudAlquilerVenta>(); */
		/* public virtual ICollection<InmuebleTasacion> InmueblesTasaciones { get; } = new List<InmuebleTasacion>(); */
		/* public virtual ICollection<Mensaje> MensajesUsuarioDe { get; } = new List<Mensaje>(); */
		/* public virtual ICollection<Mensaje> MensajesUsuarioPara { get; } = new List<Mensaje>(); */
		/* public virtual ICollection<MensajeEnviado> MensajesEnviados { get; } = new List<MensajeEnviado>(); */
		/* public virtual ICollection<NotaSimple> NotasSimples { get; } = new List<NotaSimple>(); */
		/* public virtual ICollection<Queja> QuejasUsuario { get; } = new List<Queja>(); */
		/* public virtual ICollection<Queja> QuejasUsuarioResponsable { get; } = new List<Queja>(); */
		/* public virtual ICollection<SalaReserva> SalasReservas { get; } = new List<SalaReserva>(); */
		/* public virtual ICollection<Sucesion> Sucesiones { get; } = new List<Sucesion>(); */
		/* public virtual ICollection<Tablon> Tablones { get; } = new List<Tablon>(); */
		/* public virtual ICollection<Tarea> TareasUsuarioGestor { get; } = new List<Tarea>(); */
		/* public virtual ICollection<Tarea> TareasUsuarioDistribuidor { get; } = new List<Tarea>(); */
		/* public virtual ICollection<Tarea> TareasUsuarioSolicitante { get; } = new List<Tarea>(); */
		/* public virtual ICollection<TransferenciaUsuario> TransferenciasUsuarios { get; } = new List<TransferenciaUsuario>(); */
		/* public virtual ICollection<UrgenciaAgenda> UrgenciasEntradas { get; } = new List<UrgenciaAgenda>(); */
		/* public virtual ICollection<UrgenciaFondoSolidario> UrgenciasFondosSolidariosRevisor { get; } = new List<UrgenciaFondoSolidario>(); */
		/* public virtual ICollection<UrgenciaFondoSolidario> UrgenciasFondosSolidariosAutorizador { get; } = new List<UrgenciaFondoSolidario>(); */
		/* public virtual ICollection<UrgenciaFondoSolidario> UrgenciasFondosSolidariosSolicitante { get; } = new List<UrgenciaFondoSolidario>(); */
		/* public virtual ICollection<UrgenciaFondoSolidario> UrgenciasFondosSolidariosPagador { get; } = new List<UrgenciaFondoSolidario>(); */
		/* public virtual ICollection<UrgenciaFondoSolidario> UrgenciasFondosSolidariosVerificador { get; } = new List<UrgenciaFondoSolidario>(); */
		/* public virtual ICollection<Vale> ValesSolicitante { get; } = new List<Vale>(); */
		/* public virtual ICollection<Vale> ValesRevisor { get; } = new List<Vale>(); */
		/* public virtual ICollection<Vale> ValesAutorizador { get; } = new List<Vale>(); */
		/* public virtual ICollection<VehiculoEntidadReserva> VehiculosEntidadesReservas { get; } = new List<VehiculoEntidadReserva>(); */
		/* public virtual ICollection<Voluntariado> VoluntariadosUsuario { get; } = new List<Voluntariado>(); */
		/* public virtual ICollection<Voluntariado> VoluntariadosVoluntario { get; } = new List<Voluntariado>(); */
		public virtual ICollection<ConsultaAlmacenada> ConsultasAlmacenadas { get; } = new List<ConsultaAlmacenada>(); 
		/* public virtual ICollection<Evento> Eventos { get; } = new List<Evento>(); */
		public virtual ICollection<Grupo> Grupos { get; } = new List<Grupo>();
		/* public virtual ICollection<Felicitacion> Felicitaciones { get; } = new List<Felicitacion>(); */
		/* public virtual ICollection<Permiso> Permisos { get; } = new List<Permiso>(); */
	}
}