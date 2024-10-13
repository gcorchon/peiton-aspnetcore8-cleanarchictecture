namespace Peiton.Contracts.AvisosTributarios;

public class GuardarAvisoTributarioRequest
{
    public int TuteladoId { get; set; }
    public int TipoAvisoTributarioId { get; set; }
    public int? InmuebleId { get; set; }
    public string? Comentarios { get; set; }
    public int? Ano { get; set; }
}