namespace Peiton.Core.Entities
{
    public class InmuebleAvisoCoste
	{
		public int InmuebleAvisoId { get; set; }
		public int Orden { get; set; }
		public int EmpresaId { get; set; }
		public decimal Importe { get; set; }
		public string? DocumentoPago { get; set; }
		public string? CosteId { get; set; }
		public virtual Empresa Empresa { get; set; }= null!;
		public virtual InmuebleAviso InmuebleAviso { get; set; }= null!;

	}
}