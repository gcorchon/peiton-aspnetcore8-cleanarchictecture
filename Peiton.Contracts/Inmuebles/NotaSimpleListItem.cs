namespace Peiton.Contracts.Inmuebles;
public class NotaSimpleListItem
{
    public int Id { get; set; }
    public string Tutelado { get; set; } = null!;
    public string Texto { get; set; } = null!;
    public string? DireccionCompleta { get; set; } = null!;
    public string Causa { get; set; } = null!;
    public string? Trabajador { get; set; } = null!;
    public string Estado { get; set; } = null!;
    public bool Finalizado { get; set; }
    public DateTime Fecha { get; set; }
}
