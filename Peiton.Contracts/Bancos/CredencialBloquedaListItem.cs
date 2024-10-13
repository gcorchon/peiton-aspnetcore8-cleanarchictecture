namespace Peiton.Contracts.Bancos;

public class CredencialBloquedaListItem
{
    public int Id { get; set; }
    public DateTime? UltimaEjecucionCorrecta { get; set; }
    public string NumeroExpediente { get; set; } = "";
    public string Dni { get; set; } = "";
    public string EntidadFinanciera { get; set; } = "";
    public string Tutelado { get; set; } = "";
    public string? Nombramiento { get; set; } = "";
}