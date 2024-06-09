namespace Peiton.Core.Entities
{
    public class Procedimiento
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public bool Normal { get; set; }
		public bool Adicional { get; set; }
		public int OrdenJurisdiccionalId { get; set; }
		public virtual OrdenJurisdiccional OrdenJurisdiccional { get; set; }= null!;
		/* public virtual ICollection<DatosJuridicos> DatosJuridicos { get; } = new List<DatosJuridicos>(); */
		/* public virtual ICollection<DatosJuridicosHistorico> DatosJuridicosHistoricos { get; } = new List<DatosJuridicosHistorico>(); */
		/* public virtual ICollection<ProcedimientoAdicional> ProcedimientosAdicionales { get; } = new List<ProcedimientoAdicional>(); */
		/* public virtual ICollection<Urgencia> Urgencias { get; } = new List<Urgencia>(); */

	}
}