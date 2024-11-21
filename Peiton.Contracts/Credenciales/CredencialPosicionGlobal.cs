namespace Peiton.Contracts.Credenciales;

public class CredencialPosicionGlobal
{
    public int Id { get; set; }
    public string EntidadFinanciera { get; set; } = null!;
    public string EntidadFinancieraCssClass { get; set; } = null!;
    public DateTime? UltimaEjecucion { get; set; }
    public DateTime? UltimaEjecucionCorrecta { get; set; }
    public bool Ok { get; set; }
}