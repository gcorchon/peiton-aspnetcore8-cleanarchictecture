namespace Peiton.Core.Entities
{
    public class ApoyoInformal
	{
		public int TuteladoId { get; set; }
		public int Orden { get; set; }
		public int? TipologiaApoyoInformalId { get; set; }
		public string? Parentesco { get; set; }
		public string? Nombre { get; set; }
		public int? RelacionApoyoInformalId { get; set; }
		public int? FrecuenciaApoyoInformalId { get; set; }
		public bool Conflictiva { get; set; }
		public virtual FrecuenciaApoyoInformal? FrecuenciaApoyoInformal { get; set; }
		public virtual RelacionApoyoInformal? RelacionApoyoInformal { get; set; }
		public virtual TipologiaApoyoInformal? TipologiaApoyoInformal { get; set; }
		public virtual Tutelado Tutelado { get; set; }= null!;

	}
}