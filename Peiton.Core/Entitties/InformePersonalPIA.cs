namespace Peiton.Core.Entities
{
	public class InformePersonalPIA
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public DateTime Fecha { get; set; }
		public int UsuarioId { get; set; }
		public byte[] Informe { get; set; } = [];
		public string IP { get; set; } = null!;
		public bool EsMedidaAdecuada { get; set; }
		public int? MedidaPIAId { get; set; }
		public int? ParticipacionUsuarioPIAId { get; set; }
		public virtual MedidaPIA? MedidaPIA { get; set; }
		public virtual ParticipacionUsuarioPIA? ParticipacionUsuarioPIA { get; set; }
		public virtual Tutelado Tutelado { get; set; } = null!;
		public virtual Usuario Usuario { get; set; } = null!;

	}
}