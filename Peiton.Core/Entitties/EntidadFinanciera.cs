namespace Peiton.Core.Entities
{
	public class EntidadFinanciera
	{
		public int Id { get; set; }
		public string Descripcion { get; set; } = null!;
		public string Codigo { get; set; } = null!;
		public string EurobitsID { get; set; } = null!;
		public string Productos { get; set; } = null!;
		public string Campos { get; set; } = null!;
		public string? FormatString { get; set; }
		public string? CssClass { get; set; }
		public bool Robot { get; set; }
		public string? SMSRegex { get; set; }
		public int Dias { get; set; }
		public string? AfterbanksID { get; set; }
		public string? AfterbanksFieldsMapping { get; set; }

		public virtual ICollection<Credencial> Credenciales { get; } = new List<Credencial>();
		/* public virtual ICollection<CredencialCP> CredencialesCP { get; } = new List<CredencialCP>(); */
		/* public virtual ICollection<CredencialMasiva> CredencialesMasivas { get; } = new List<CredencialMasiva>(); */
		/* public virtual ICollection<EfectoPublico> EfectosPublicos { get; } = new List<EfectoPublico>(); */
		/* public virtual ICollection<EscritoSucursal> EscritosSucursales { get; } = new List<EscritoSucursal>(); */
		/* public virtual ICollection<PlanDePension> PlanesDePensiones { get; } = new List<PlanDePension>(); */
		/* public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>(); */
		/* public virtual ICollection<ProductoManual> ProductosManuales { get; } = new List<ProductoManual>(); */
		/* public virtual ICollection<Sucursal> Sucursales { get; } = new List<Sucursal>(); */

	}
}