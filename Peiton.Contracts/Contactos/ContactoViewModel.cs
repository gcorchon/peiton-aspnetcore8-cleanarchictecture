namespace Peiton.Contracts.Contactos;

public class ContactoViewModel
{
    public int Orden { get; set; }
    public string Tipo { get; set; } = null!;
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    public string? Comentarios { get; set; }
    public string? email { get; set; }
    public int? ContactoRelacionId { get; set; }
    public string? Direccion { get; set; }
}