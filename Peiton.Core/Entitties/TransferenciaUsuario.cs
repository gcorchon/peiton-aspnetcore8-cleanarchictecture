namespace Peiton.Core.Entities
{
    public class TransferenciaUsuario
	{
		public int UsuarioId { get; set; }
		public int EntidadFinancieraId { get; set; }
		public string Data { get; set; } = null!;
		public virtual Usuario Usuario { get; set; }= null!;

	}
}