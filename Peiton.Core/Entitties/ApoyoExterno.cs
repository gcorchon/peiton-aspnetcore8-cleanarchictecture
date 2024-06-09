namespace Peiton.Core.Entities
{
    public class ApoyoExterno
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public bool Domicilio { get; set; }
		public bool Centros { get; set; }

		/* public virtual ICollection<Tutelado> Tutelados { get; } = new List<Tutelado>(); */
	}
}