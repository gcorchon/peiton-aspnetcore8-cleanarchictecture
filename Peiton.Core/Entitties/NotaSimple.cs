namespace Peiton.Core.Entities
{
    public class NotaSimple
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public int CausaNotaSimpleId { get; set; }
		public string Descripcion { get; set; } = null!;
		public DateTime Fecha { get; set; }
		public bool Finalizado { get; set; }
		public int? UsuarioId { get; set; }
		public int? InmuebleId { get; set; }
		public virtual Inmueble? Inmueble { get; set; }
		public virtual CausaNotaSimple CausaNotaSimple { get; set; }= null!;
		public virtual Tutelado Tutelado { get; set; }= null!;
		public virtual Usuario? Usuario { get; set; }

	}
}