namespace Peiton.Contracts.MensajesTuAppoyo;

public class MensajeTuAppoyoEnviadoListItem
{
    public int Id { get; set; }
    public string Asunto { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public string Destinatario { get; set; } = null!;
    public string Avatar { get; set; } = null!;
}