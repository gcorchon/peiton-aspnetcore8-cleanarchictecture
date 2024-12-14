namespace Peiton.Contracts.EscritosSucursales;

public class GuardarEscritoSucursalRequest
{
	public int EntidadFinancieraId { get; set; }
	public string Numero { get; set; } = null!;   
	public DateTime? InformadaTutela { get; set; }
	public DateTime? SolicitudBloqueo { get; set; }
	public DateTime? PeticionClaves { get; set; }
	public DateTime? RecepcionClaves { get; set; }
	public DateTime? PrimeraSolicitud { get; set; }
	public DateTime? SegundaSolicitud { get; set; }
}