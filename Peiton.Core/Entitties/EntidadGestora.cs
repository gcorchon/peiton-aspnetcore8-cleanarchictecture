namespace Peiton.Core.Entities
{
    public class EntidadGestora
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;
		public int? ComunidadAutonomaId { get; set; }
		public int? ProvinciaId { get; set; }
		public string? Municipio { get; set; }
		public string? CodigoPostal { get; set; }
		public string? Direccion { get; set; }
		public string? Telefono { get; set; }
		public string? Fax { get; set; }
		public string? Email { get; set; }
		public string? Web { get; set; }
		public DateTime? FechaConstitucion { get; set; }
		public DateTime? FechaRegistroFundaciones { get; set; }
		public string? NumeroInscripcionRegistroFundaciones { get; set; }
		public DateTime? FechaRegistroUnificadoServiciosSociales { get; set; }
		public string? NumeroInscripcionRegistroUnificadoServiciosSociales { get; set; }
		public string? CIF { get; set; }
		public int? TitularidadServicioEntidadGestoraId { get; set; }
		public string? Representante { get; set; }
		public int? AmbitoCoberturaServicioId { get; set; }
		public string? Finalidad { get; set; }
		public string? Observaciones { get; set; }
		public virtual AmbitoCoberturaServicio? AmbitoCoberturaServicio { get; set; }
		public virtual ComunidadAutonoma? ComunidadAutonoma { get; set; }
		public virtual Provincia? Provincia { get; set; }
		public virtual TitularidadServicioEntidadGestora? TitularidadServicioEntidadGestora { get; set; }
		/* public virtual ICollection<ActividadEspecializada> ActividadesEspecializadas { get; } = new List<ActividadEspecializada>(); */
		/* public virtual ICollection<EquipoAtencionEntidadGestora> EquiposAtencionesEntidadesGestoras { get; } = new List<EquipoAtencionEntidadGestora>(); */
		/* public virtual ICollection<PerfilUsuarioEntidadGestora> PerfilesUsuariosEntidadesGestoras { get; } = new List<PerfilUsuarioEntidadGestora>(); */
		/* public virtual ICollection<Tutelado> Tutelados { get; } = new List<Tutelado>(); */

	}
}