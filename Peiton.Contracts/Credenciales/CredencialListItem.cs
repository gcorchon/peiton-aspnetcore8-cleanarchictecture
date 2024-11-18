namespace Peiton.Contracts.Credenciales;

public class CredencialListItem
{
    public int Id { get; set; }
    public IEnumerable<CampoCredencial> Campos { get; set; } = null!;
    public string EntidadFinancieraId { get; set; } = null!;
    public string EntidadFinancieraCssClass { get; set; } = null!;
    public bool DetenerRobot { get; set; }
}