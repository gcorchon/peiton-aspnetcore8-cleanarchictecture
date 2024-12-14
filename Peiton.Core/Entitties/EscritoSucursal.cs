namespace Peiton.Core.Entities;
public class EscritoSucursal
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public int EntidadFinancieraId { get; set; }
	public string Numero { get; set; } = null!;
	public DateTime? InformadaTutela { get; set; }
	public DateTime? SolicitudBloqueo { get; set; }
	public DateTime? PeticionClaves { get; set; }
	public DateTime? RecepcionClaves { get; set; }
	public DateTime? PrimeraSolicitud { get; set; }
	public DateTime? SegundaSolicitud { get; set; }
	public virtual EntidadFinanciera EntidadFinanciera { get; set; } = null!;
	public virtual Tutelado Tutelado { get; set; } = null!;

}
