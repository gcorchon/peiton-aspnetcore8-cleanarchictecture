namespace Peiton.Contracts.ApoyosInformales;

public class ApoyoInformalViewModel
{
    public int Orden { get; set; }
    public int? TipologiaApoyoInformalId { get; set; }
    public string? Parentesco { get; set; }
    public string? Nombre { get; set; }
    public int? RelacionApoyoInformalId { get; set; }
    public int? FrecuenciaApoyoInformalId { get; set; }
    public bool Conflictiva { get; set; }
}