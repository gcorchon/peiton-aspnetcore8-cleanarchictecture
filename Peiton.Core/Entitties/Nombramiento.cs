using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class Nombramiento
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public bool Procesar { get; set; }
	public bool CargoSalud { get; set; }
	public bool CargoEconomico { get; set; }

	/* public virtual ICollection<ControlCuentaGeneral> ControlesCuentasGeneralesNombramientoArchivado { get; } = new List<ControlCuentaGeneral>(); */
	/* public virtual ICollection<ControlCuentaGeneral> ControlesCuentasGeneralesNombramientoPresentada { get; } = new List<ControlCuentaGeneral>(); */
	/* public virtual ICollection<ControlInventario> ControlesInventarios { get; } = new List<ControlInventario>(); */
	/* public virtual ICollection<ControlRendicion> ControlesRendiciones { get; } = new List<ControlRendicion>(); */
	/* public virtual ICollection<DatosJuridicos> DatosJuridicosNombramiento { get; } = new List<DatosJuridicos>(); */
	/* public virtual ICollection<DatosJuridicos> DatosJuridicosNombramiento2 { get; } = new List<DatosJuridicos>(); */
	/* public virtual ICollection<DatosJuridicosHistorico> DatosJuridicosHistoricosNombramiento { get; } = new List<DatosJuridicosHistorico>(); */
	/* public virtual ICollection<DatosJuridicosHistorico> DatosJuridicosHistoricosNombramiento2 { get; } = new List<DatosJuridicosHistorico>(); */

}
