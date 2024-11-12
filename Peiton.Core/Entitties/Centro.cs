using System.Linq;
namespace Peiton.Core.Entities;
public class Centro
{
	public int Id { get; set; }
	public string Nombre { get; set; } = null!;
	public string? Via { get; set; }
	public string? Direccion { get; set; }
	public string? Numero { get; set; }
	public string? CP { get; set; }
	public string? Poblacion { get; set; }
	public string? Distrito { get; set; }
	public string? Provincia { get; set; }
	public string? Telefono1 { get; set; }
	public string? Telefono2 { get; set; }
	public string? Fax { get; set; }
	public string? Observaciones { get; set; }
	public string? Portal { get; set; }
	public string? Escalera { get; set; }
	public string? Piso { get; set; }
	public string? Letra { get; set; }
	public int Tipologia { get; set; }
	public bool Amas { get; set; }
	public bool Residencial { get; set; }
	public bool Diurno { get; set; }

	/* public virtual ICollection<ApoyoFormal> ApoyosFormales { get; } = new List<ApoyoFormal>(); */
	/* public virtual ICollection<ResidenciaHabitual> ResidenciasHabituales { get; } = new List<ResidenciaHabitual>(); */
	/* public virtual ICollection<ResidenciaHabitualHistorico> ResidenciasHabitualesHistoricos { get; } = new List<ResidenciaHabitualHistorico>(); */

	public string? DireccionCompleta
	{
		get
		{
			string? provincia = null;
			if (!string.IsNullOrWhiteSpace(Provincia))
			{
				provincia = $"({Provincia})";
			}

			var parts1 = new string?[] { Via, Direccion, Numero }.Where(p => !string.IsNullOrWhiteSpace(p)).Select(p => p!.Trim());

			if (!parts1.Any()) return null;

			var parts2 = new string?[] { CP, Poblacion, provincia }.Where(p => !string.IsNullOrWhiteSpace(p)).Select(p => p!.Trim());

			var fullParts = new List<string>() { string.Join(" ", parts1) };

			if (parts2.Any())
			{
				fullParts.Add(string.Join(" ", parts2));
			}

			return string.Join(", ", fullParts);
		}
	}
}
