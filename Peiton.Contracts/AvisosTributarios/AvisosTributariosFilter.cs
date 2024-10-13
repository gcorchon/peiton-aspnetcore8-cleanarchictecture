namespace Peiton.Contracts.AvisosTributarios;

public class AvisosTributariosFilter
{
    public string? Id { get; set; }
    public string? Tutelado { get; set; }
    public string? Usuario { get; set; }
    public int? TipoAvisoTributarioId { get; set; }
    public int? Estado { get; set; }
}