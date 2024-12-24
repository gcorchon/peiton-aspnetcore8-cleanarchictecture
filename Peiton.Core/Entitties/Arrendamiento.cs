namespace Peiton.Core.Entities;
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
	public virtual Provincia Provincia { get; set; } = null!;
	public virtual TipoVia TipoVia { get; set; } = null!;
	public virtual Tutelado Tutelado { get; set; } = null!;
	/* public virtual ICollection<ArrendamientoInquilino> ArrendamientosInquilinos { get; } = new List<ArrendamientoInquilino>(); */

	public string ObtenerDireccion()
	{
		var partes = new List<string>();
		var parte1 = new List<string>();
		var parte2 = new List<string>();
		var parte3 = new List<string>();

		if (this.TipoVia != null) parte1.Add(this.TipoVia.Descripcion);
		if (!string.IsNullOrWhiteSpace(this.NombreVia)) parte1.Add(this.NombreVia);
		if (!string.IsNullOrWhiteSpace(this.Numero)) parte1.Add(this.Numero);

		if (parte1.Count > 0) partes.Add(string.Join(" ", parte1));

		if (!string.IsNullOrWhiteSpace(this.Portal)) parte2.Add("Portal " + this.Portal);
		if (!string.IsNullOrWhiteSpace(this.Escalera)) parte2.Add("Esc. " + this.Escalera);
		if (!string.IsNullOrWhiteSpace(this.Piso)) parte2.Add("Piso " + this.Piso);
		if (!string.IsNullOrWhiteSpace(this.Puerta)) parte2.Add("Puerta " + this.Puerta);


		if (parte2.Count > 0) partes.Add(string.Join(" ", parte2));

		if (!string.IsNullOrWhiteSpace(this.CodigoPostal)) parte3.Add(this.CodigoPostal);

		var temp = new List<string>();
		if (!string.IsNullOrWhiteSpace(this.Municipio)) temp.Add(this.Municipio);
		if (this.Distrito != null) temp.Add(this.Distrito.Descripcion);


		if (temp.Count > 0)
			parte3.Add(string.Join(" - ", temp));

		if (this.Provincia != null) parte3.Add("(" + this.Provincia.Nombre + ")");

		partes.Add(string.Join(" ", parte3));

		return string.Join(", ", partes);
	}
}
