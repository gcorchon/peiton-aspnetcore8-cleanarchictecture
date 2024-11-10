namespace Peiton.Contracts.MensajesTuAppoyo;

public class MensajeTuAppoyoListItem
{
    public int Id { get; set; }
    public int TuteladoId { get; set; }
    public string Asunto { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public bool Leido { get; set; }
    public string Remitente { get; set; } = null!;
    public string Avatar { get; set; } = null!;
}