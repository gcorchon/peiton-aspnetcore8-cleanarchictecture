namespace Peiton.Core.Entities
{
    public class TuteladoObjetivo
	{
		public int TuteladoId { get; set; }
		public int TipoObjetivoId { get; set; }
		public int Orden { get; set; }
		public string? Texto { get; set; }
		public int? ObjetivoSocialId { get; set; }
		public DateTime? Fecha { get; set; }
		public bool? Conseguido { get; set; }
		public string? Tareas { get; set; }
		public bool? NoConseguido { get; set; }
		public virtual ObjetivoSocial? ObjetivoSocial { get; set; }
		public virtual TipoObjetivo TipoObjetivo { get; set; }= null!;
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}