namespace Peiton.Core.Entities
{
    public class Vale
	{
		public int Id { get; set; }
		public int SolicitanteId { get; set; }
		public int? RevisorId { get; set; }
		public int? AutorizadorId { get; set; }
		public DateTime FechaSolicitud { get; set; }
		public DateTime? FechaPago { get; set; }
		public decimal Importe { get; set; }
		public string? ObservacionesSolicitud { get; set; }
		public string? Archivos { get; set; }
		public string? ObservacionesAutorizacion { get; set; }
		public bool Revisado { get; set; }
		public bool Autorizado { get; set; }
		public bool Pagado { get; set; }
		public bool Rechazado { get; set; }
		public DateTime? FechaRevision { get; set; }
		public DateTime? FechaAutorizacion { get; set; }
		public virtual Usuario Solicitante { get; set; }= null!;
		public virtual Usuario? Revisor { get; set; }
		public virtual Usuario? Autorizador { get; set; }

	}
}