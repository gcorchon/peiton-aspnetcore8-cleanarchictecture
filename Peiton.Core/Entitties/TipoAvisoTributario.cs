namespace Peiton.Core.Entities
{
    public class TipoAvisoTributario
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public bool Inmueble { get; set; }
		public bool IRPF { get; set; }

		/* public virtual ICollection<AvisoTributario> AvisosTributarios { get; } = new List<AvisoTributario>(); */

	}
}