namespace Peiton.Core.Entities
{
    public class Cliente
	{
		public int Id { get; set; }
		public string CodCliente { get; set; } = null!;
		public string Nombre { get; set; } = null!;
		public bool Activo { get; set; }
		public string? CIF { get; set; }

		public virtual ICollection<Asiento> Asientos { get; } = new List<Asiento>();

	}
}