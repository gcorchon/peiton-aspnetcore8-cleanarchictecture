namespace Peiton.Core.Entities
{
    public class ControlRendicion
	{
		public int Id { get; set; }
		public int TuteladoId { get; set; }
		public int TipoRendicionId { get; set; }
		public DateTime? FechaInicioIncidencia { get; set; }
		public DateTime? FechaFinIncidencia { get; set; }
		public int? TipoIncidencia { get; set; }
		public DateTime? FechaInicioRendicion { get; set; }
		public DateTime? FechaFinRendicion { get; set; }
		public DateTime? FechaSalidaAMTA { get; set; }
		public DateTime? FechaRecepcionJuzgado { get; set; }
		public int? JuzgadoId { get; set; }
		public int? NombramientoId { get; set; }
		public decimal? RendimientoLiquido { get; set; }
		public int? EstadoAprobacionRendicionId { get; set; }
		public DateTime? FechaRendicionAprobada { get; set; }
		public int? TipoAprobacionRendicionId { get; set; }
		public DateTime? FechaRendicionDenegada { get; set; }
		public string? Observaciones { get; set; }
		public int? EstadoRetribucionId { get; set; }
		public DateTime? FechaRetribucionConcedida { get; set; }
		public decimal? Porcentaje { get; set; }
		public decimal? Importe { get; set; }
		public string? Cuenta { get; set; }
		public string? OtraCuenta { get; set; }
		public DateTime? FechaTransferencia { get; set; }
		public DateTime? FechaCobro { get; set; }
		public decimal? ImporteReal { get; set; }
		public DateTime? FechaRetribucionCondicionada { get; set; }
		public DateTime? FechaRetribucionDenegada { get; set; }
		public int? ArchivoRendicionId { get; set; }
		public int? ArchivoAprobacionId { get; set; }
		public DateTime? FechaLimite { get; set; }
		public virtual Archivo? ArchivoAprobacion { get; set; }
		public virtual Archivo? ArchivoRendicion { get; set; }
		public virtual EstadoAprobacionRendicion? EstadoAprobacionRendicion { get; set; }
		public virtual EstadoRetribucion? EstadoRetribucion { get; set; }
		public virtual Juzgado? Juzgado { get; set; }
		public virtual Nombramiento? Nombramiento { get; set; }
		public virtual TipoAprobacionRendicion? TipoAprobacionRendicion { get; set; }
		public virtual TipoRendicion TipoRendicion { get; set; }= null!;
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}