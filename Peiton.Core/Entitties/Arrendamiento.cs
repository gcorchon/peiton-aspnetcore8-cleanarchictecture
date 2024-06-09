namespace Peiton.Core.Entities
{
    public class Arrendamiento
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public int TipoViaId { get; set; }
		public string NombreVia { get; set; } = null!;
		public string? Numero { get; set; }
		public string? Portal { get; set; }
		public string? Escalera { get; set; }
		public string? Piso { get; set; }
		public string? Puerta { get; set; }
		public string? CodigoPostal { get; set; }
		public string? Municipio { get; set; }
		public string? Barrio { get; set; }
		public int? DistritoId { get; set; }
		public int ProvinciaId { get; set; }
		public string? RegistroCiudad { get; set; }
		public string? RegistroNumero { get; set; }
		public string? RegistroInscripcionReferencia { get; set; }
		public string? RegistroReferenciaCatastral { get; set; }
		public string? Observaciones { get; set; }
		public DateTime? FechaInicioArrendamiento { get; set; }
		public DateTime? FechaFinArrendamiento { get; set; }
		public DateTime? UltimaActualizacionArrendamiento { get; set; }
		public decimal? RentaMensualArrendamiento { get; set; }
		public bool? FianzaArrendamiento { get; set; }
		public bool? AvalBancarioArrendamiento { get; set; }
		public int? AgenteArrendamientoId { get; set; }
		public string? DireccionCompleta { get; set; }
		public virtual AgenteArrendamiento? AgenteArrendamiento { get; set; }
		public virtual Distrito? Distrito { get; set; }
		public virtual Provincia Provincia { get; set; }= null!;
		public virtual TipoVia TipoVia { get; set; }= null!;
		public virtual Tutelado Tutelado { get; set; }= null!;
		/* public virtual ICollection<ArrendamientoInquilino> ArrendamientosInquilinos { get; } = new List<ArrendamientoInquilino>(); */

	}
}