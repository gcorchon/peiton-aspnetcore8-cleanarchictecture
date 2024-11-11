namespace Peiton.Contracts.Directorio;

public class DirectorioListItem
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = null!;
    public string? Cargo { get; set; }
    public string? Grupos { get; set; }
    public string? TelefonoFijo { get; set; }
    public string? Extension { get; set; }
    public string? TelefonoMovil { get; set; }
    public string? Email { get; set; }
    public string? Imagen { get; set; }
    public string? CPU { get; set; }
    public string? Monitor { get; set; }
    public string? Edificio { get; set; }
    public string? Planta { get; set; }
}