namespace Peiton.Core.Entities
{
    public class ConsultaAlmacenada
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public string Query { get; set; } = null!;
		public DateTime Fecha { get; set; }
		public int CategoriaConsultaId { get; set; }
		public string? Resumen { get; set; }
		public virtual CategoriaConsulta CategoriaConsulta { get; set; }= null!;

		public virtual ICollection<Grupo> Grupos { get; } = new List<Grupo>();
		public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
	}
}