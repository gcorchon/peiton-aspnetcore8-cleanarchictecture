using System.Globalization;
using System.Text.RegularExpressions;

namespace Peiton.Core.Entities;
public class ResidenciaHabitual
{
	public int TuteladoId { get; set; }
	public string Tipo { get; set; } = null!;
	public int? CentroId { get; set; }
	public DateTime? FechaIngreso { get; set; }
	public int? TipoCentroId { get; set; }
	public int? TipoFinanciacionId { get; set; }
	public int? TipoFinanciacionPublicaId { get; set; }
	public bool? AnticiposResidencia { get; set; }
	public bool? EstanciaTemporal { get; set; }
	public int? TipoViaId { get; set; }
	public string? Direccion { get; set; }
	public string? Numero { get; set; }
	public string? Portal { get; set; }
	public string? Escalera { get; set; }
	public string? Piso { get; set; }
	public string? Puerta { get; set; }
	public string? CodigoPostal { get; set; }
	public string? Municipio { get; set; }
	public int? ProvinciaId { get; set; }
	public string? Telefono1 { get; set; }
	public string? Telefono2 { get; set; }
	public int? DistritoId { get; set; }
	public bool? ChequeServicio { get; set; }
	public bool? PagoAMTA { get; set; }
	public bool? PagaTutelado { get; set; }
	public bool? PagaFamiliar { get; set; }
	public double? Latitud { get; set; }
	public double? Longitud { get; set; }
	public string? Observaciones {get; set; }
	public virtual Centro? Centro { get; set; }
	public virtual Distrito? Distrito { get; set; }
	public virtual Provincia? Provincia { get; set; }
	public virtual TipoCentro? TipoCentro { get; set; }
	public virtual TipoFinanciacionPublica? TipoFinanciacionPublica { get; set; }
	public virtual TipoVia? TipoVia { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;


	private string? _direccionCompleta = null!;
	public string? DireccionCompleta
	{
		get
		{
			if (_direccionCompleta == null && !string.IsNullOrWhiteSpace(this.Direccion))
			{
				List<string> parts1 = [];
				if (this.TipoViaId.HasValue) parts1.Add(this.TipoVia!.Descripcion);
				parts1.Add(this.Direccion);
				if (!string.IsNullOrWhiteSpace(this.Numero)) parts1.Add(this.Numero);

				List<string> parts2 = [];
				if (!string.IsNullOrWhiteSpace(this.Portal)) parts2.Add("Portal " + this.Portal);
				if (!string.IsNullOrWhiteSpace(this.Escalera)) parts2.Add("Esc. " + this.Escalera);
				if (!string.IsNullOrWhiteSpace(this.Piso)) parts2.Add("Piso " + this.Piso);
				if (!string.IsNullOrWhiteSpace(this.Puerta)) parts2.Add("Pta. " + this.Puerta);

				List<string> parts3 = [];
				if (!string.IsNullOrWhiteSpace(this.CodigoPostal)) parts3.Add(this.CodigoPostal);
				if (!string.IsNullOrWhiteSpace(this.Municipio)) parts3.Add(this.Municipio);
				if (this.ProvinciaId.HasValue) parts3.Add("(" + this.Provincia!.Nombre + ")");

				List<string> parts = [String.Join(" ", parts1)];
				if (parts2.Count > 0) parts.Add(String.Join(" ", parts2));
				if (parts3.Count > 0) parts.Add(String.Join(" ", parts3));

				_direccionCompleta = String.Join(", ", parts);

			}
			return _direccionCompleta;
		}
	}

	public string? DireccionGeolocalizacion
	{
		get
		{
			if (string.IsNullOrWhiteSpace(this.Direccion) || string.IsNullOrWhiteSpace(this.Municipio)) return null;

			List<string> parts = [];
			List<string> parts1 = [];

			if (this.TipoViaId.HasValue) parts1.Add(this.TipoVia!.Descripcion);
			parts1.Add(this.Direccion);

			parts.Add(String.Join(" ", parts1));

			if (!string.IsNullOrWhiteSpace(this.Numero)) parts.Add(this.Numero);

			List<string> parts3 = [];
			if (!string.IsNullOrEmpty(this.CodigoPostal))
			{
				parts3.Add(this.CodigoPostal);
			}
			parts3.Add(this.Municipio);

			parts.Add(String.Join(" ", parts3));

			if (this.ProvinciaId.HasValue)
			{
				parts.Add(this.Provincia!.Nombre);
			}
			else if (!string.IsNullOrWhiteSpace(this.CodigoPostal) && Regex.IsMatch(CodigoPostal, @"\d{5}"))
			{
				var provincias = new Dictionary<string, string>(){ { "01", "Álava" }, { "02", "Albacete" }, { "03", "Alicante" }, { "04", "Almería" }, { "05", "Ávila" },
				{ "06", "Badajoz" }, { "07", "Islas Baleares" }, { "08", "Barcelona" }, { "09", "Burgos" }, { "10", "Cáceres" },
				{ "11", "Cádiz" }, { "12", "Castellón" }, { "13", "Ciudad Real" }, { "14", "Córdoba" }, { "15", "La Coruña" },
				{ "16", "Cuenca" }, { "17", "Gerona" }, { "18", "Granada" }, { "19", "Guadalajara" }, { "20", "Guipúzcoa" },
				{ "21", "Huelva" }, { "22", "Huesca" }, { "23", "Jaén" }, { "24", "León" }, { "25", "Lérida" }, { "26", "La Rioja" },
				{ "27", "Lugo" }, { "28", "Madrid" }, { "29", "Málaga" }, { "30", "Murcia" }, { "31", "Navarra" }, { "32", "Orense" },
				{ "33", "Asturias" }, { "34", "Palencia" }, { "35", "Las Palmas" }, { "36", "Pontevedra" }, { "37", "Salamanca" },
				{ "38", "Santa Cruz de Tenerife" }, { "39", "Cantabria" }, { "40", "Segovia" }, { "41", "Sevilla" }, { "42", "Soria" },
				{ "43", "Tarragona" }, { "44", "Teruel" }, { "45", "Toledo" }, { "46", "Valencia" }, { "47", "Valladolid" },
				{ "48", "Bizkaia" }, { "49", "Zamora" }, { "50", "Zaragoza" }, { "51", "Ceuta" }, { "52", "Melilla" }, };

				var codigo = this.CodigoPostal[..2];
				if (provincias.ContainsKey(codigo))
				{
					parts.Add(provincias[codigo]);
				}
			}
			parts.Add("España");

			var textInfo = new CultureInfo("es-ES", false).TextInfo;
			return textInfo.ToTitleCase(String.Join(", ", parts).ToLower());
		}
	}

	public string? DireccionGeolocalizacionIncompleta
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(this.Direccion))
			{
				List<string> parts = [];

				List<string> parts1 = [];
				if (this.TipoViaId.HasValue) parts1.Add(this.TipoVia!.Descripcion);
				parts1.Add(this.Direccion);
				parts.Add(string.Join(" ", parts1));

				if (!string.IsNullOrWhiteSpace(this.Numero)) parts.Add(this.Numero);

				List<string> parts2 = [];
				if (!string.IsNullOrWhiteSpace(this.CodigoPostal)) parts2.Add(this.CodigoPostal);
				if (!string.IsNullOrWhiteSpace(this.Municipio)) parts2.Add(this.Municipio);

				if (parts2.Count > 0) parts.Add(String.Join(" ", parts2));

				if (this.ProvinciaId.HasValue)
				{
					parts.Add(this.Provincia!.Nombre);
				}

				return String.Join(", ", parts);
			}

			return null;
		}
	}
}
