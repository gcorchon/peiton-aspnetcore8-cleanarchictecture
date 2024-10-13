namespace Peiton.Core.Entities;
public class MensajeEnviado
{
	public int Id { get; set; }
	public int? MensajeId { get; set; }
	public DateTime Fecha { get; set; }
	public int Usuario_DeId { get; set; }
	public string Para { get; set; } = null!;
	public string ConCopia { get; set; } = null!;
	public string Asunto { get; set; } = null!;
	public string Cuerpo { get; set; } = null!;
	public int? Dias { get; set; }
	public virtual Mensaje? Mensaje { get; set; }
	public virtual Usuario UsuarioDe { get; set; } = null!;

}
