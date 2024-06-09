namespace Peiton.Core.Entities
{
    public class FondoSolidario
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public int FondoSolidarioTipoFondoId { get; set; }
		public int FondoSolidarioPeriodicidadId { get; set; }
		public int FondoSolidarioDestinoId { get; set; }
		public int? FondoSolidarioFormaPagoId { get; set; }
		public int SolicitanteId { get; set; }
		public int? RevisorId { get; set; }
		public int? AutorizadorId { get; set; }
		public int? PagadorId { get; set; }
		public int? VerificadorId { get; set; }
		public decimal Importe { get; set; }
		public string ObservacionesSolicitud { get; set; } = null!;
		public string? ObservacionesAutorizacion { get; set; }
		public bool FamiliaContribuye { get; set; }
		public string? Archivo { get; set; }
		public bool Revisado { get; set; }
		public bool Autorizado { get; set; }
		public bool Pagado { get; set; }
		public bool Verificado { get; set; }
		public bool Rechazado { get; set; }
		public DateTime FechaSolicitud { get; set; }
		public DateTime? FechaRevision { get; set; }
		public DateTime? FechaAutorizacion { get; set; }
		public DateTime? FechaCaducidad { get; set; }
		public DateTime? FechaPago { get; set; }
		public bool Recuperable { get; set; }
		public DateTime? FechaVerificacion { get; set; }
		public int? FondoSolidarioTarjetaPrepagoId { get; set; }
		public DateTime? FechaBaja { get; set; }
		public string? Archivo2 { get; set; }
		public int? FondoSolidarioPadreId { get; set; }
		public virtual FondoSolidarioDestino FondoSolidarioDestino { get; set; }= null!;
		public virtual FondoSolidarioFormaPago? FondoSolidarioFormaPago { get; set; }
		public virtual FondoSolidarioPeriodicidad FondoSolidarioPeriodicidad { get; set; }= null!;
		public virtual FondoSolidarioTipoFondo FondoSolidarioTipoFondo { get; set; }= null!;
		public virtual Tutelado Tutelado { get; set; }= null!;
		public virtual Usuario? Revisor { get; set; }
		public virtual Usuario? Autorizador { get; set; }
		public virtual Usuario Solicitante { get; set; }= null!;
		public virtual Usuario? Pagador { get; set; }
		public virtual FondoSolidarioTarjetaPrepago? FondoSolidarioTarjetaPrepago { get; set; }
		public virtual Usuario? Verificador { get; set; }

	}
}