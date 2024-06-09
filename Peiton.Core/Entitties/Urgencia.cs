namespace Peiton.Core.Entities
{
    public class Urgencia
	{
		public int Id { get; set; }
		public string NumeroExpediente { get; set; } = null!;
		public string Nombre { get; set; } = null!;
		public string Apellido1 { get; set; } = null!;
		public string? Apellido2 { get; set; }
		public string? Apellidos { get; set; }
		public string? DNI { get; set; }
		public string? Actuacion { get; set; }
		public DateTime? FechaActuacion { get; set; }
		public int? UrgenciaOrigenId { get; set; }
		public int? UrgenciaTipoId { get; set; }
		public int? JuzgadoId { get; set; }
		public int? TrabajadorSocialId { get; set; }
		public int? AbogadoId { get; set; }
		public int? EconomicoId { get; set; }
		public int? ProcedimientoId { get; set; }
		public string? NumeroProcedimiento { get; set; }
		public string? Comentarios { get; set; }
		public DateTime? FechaComunicadoFiscalia { get; set; }
		public bool Archivo { get; set; }
		public DateTime FechaCreacion { get; set; }
		public string? NombreCompleto { get; set; }
		public string? ObservacionesEconomico { get; set; }
		public int? FiscaliaId { get; set; }
		public string? OrigenOtros { get; set; }
		public int? UrgenciaTipoEspecimenId { get; set; }
		public bool Muerto { get; set; }
		public int? MotivoMuertoUrgenciaId { get; set; }
		public DateTime? FechaMuerto { get; set; }
		public virtual Abogado? Abogado { get; set; }
		public virtual Economico? Economico { get; set; }
		public virtual Fiscalia? Fiscalia { get; set; }
		public virtual Juzgado? Juzgado { get; set; }
		public virtual MotivoMuertoUrgencia? MotivoMuertoUrgencia { get; set; }
		public virtual Procedimiento? Procedimiento { get; set; }
		public virtual TrabajadorSocial? TrabajadorSocial { get; set; }
		public virtual UrgenciaOrigen? UrgenciaOrigen { get; set; }
		public virtual UrgenciaTipo? UrgenciaTipo { get; set; }
		public virtual UrgenciaTipoEspecimen? UrgenciaTipoEspecimen { get; set; }
		/* public virtual ICollection<UrgenciaAgenda> UrgenciasEntradas { get; } = new List<UrgenciaAgenda>(); */
		/* public virtual ICollection<UrgenciaArchivo> UrgenciasArchivos { get; } = new List<UrgenciaArchivo>(); */
		/* public virtual ICollection<UrgenciaCoste> UrgenciasCostes { get; } = new List<UrgenciaCoste>(); */
		/* public virtual ICollection<UrgenciaFondoSolidario> UrgenciasFondosSolidarios { get; } = new List<UrgenciaFondoSolidario>(); */

	}
}