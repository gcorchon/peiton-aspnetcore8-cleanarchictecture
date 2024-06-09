namespace Peiton.Core.Entities
{
    public class Archivo
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public int CategoriaArchivoId { get; set; }
		public string Descripcion { get; set; } = null!;
		public string? ContentType { get; set; }
		public string FileName { get; set; } = null!;
		public DateTime Fecha { get; set; }
		public string? Tags { get; set; }
		public bool TuAppoyo { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;
		/* public virtual ICollection<ControlCuentaGeneral> ControlesCuentasGeneralesArchivoAprobacion { get; } = new List<ControlCuentaGeneral>(); */
		/* public virtual ICollection<ControlCuentaGeneral> ControlesCuentasGeneralesArchivoCGJ { get; } = new List<ControlCuentaGeneral>(); */
		/* public virtual ICollection<ControlInventario> ControlesInventarios { get; } = new List<ControlInventario>(); */
		/* public virtual ICollection<ControlRendicion> ControlesRendicionesArchivoAprobacion { get; } = new List<ControlRendicion>(); */
		/* public virtual ICollection<ControlRendicion> ControlesRendicionesArchivoRendicion { get; } = new List<ControlRendicion>(); */
		/* public virtual ICollection<DatosJuridicos> DatosJuridicosArchivoDocumentoJura { get; } = new List<DatosJuridicos>(); */
		/* public virtual ICollection<DatosJuridicos> DatosJuridicosArchivoResolucionJudicial { get; } = new List<DatosJuridicos>(); */
		/* public virtual ICollection<DatosJuridicos> DatosJuridicosArchivoResolucionJudicialAuto { get; } = new List<DatosJuridicos>(); */

	}
}