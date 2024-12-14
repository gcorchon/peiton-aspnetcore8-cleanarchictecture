namespace Peiton.Contracts.EscritosSucursales;

public class EscritoSucursalListItem
{
	public int EntidadFinancieraId { get; set; }
	public string EntidadFinanciera { get; set; } = null!;
	public string? CssClass { get; set; }
	public string Numero { get; set; } = null!;
	public string? CodigoPostal { get; set; }
	public string? Direccion { get; set; }
	public string? Ciudad { get; set; }
	public string? Provincia { get; set; }
	public DateTime? InformadaTutela { get; set; }
	public DateTime? SolicitudBloqueo { get; set; }
	public DateTime? PeticionClaves { get; set; }
	public DateTime? RecepcionClaves { get; set; }
	public DateTime? PrimeraSolicitud { get; set; }
	public DateTime? SegundaSolicitud { get; set; }
}